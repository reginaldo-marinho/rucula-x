using Microsoft.EntityFrameworkCore;

namespace RuculaX.EntityFramework.Test;

[TestClass]
public class CrudRepositoryEntityCustomTest
{
    TestContext ctx = DbInMemory.GetContext();
    RepositoryUserDetail repositoryUserDetail;
    public CrudRepositoryEntityCustomTest()
    {
        repositoryUserDetail = new (ctx);
    }

    [TestMethod]
    public async Task GetCustomIdentityAsync()
    {
        var userDetails = new UserDetails { Id = "324909340", RowNumber = 1, Description = "First Info" };

        await repositoryUserDetail.InsertAsync(userDetails);

        await ctx.SaveChangesAsync();

        var userDetail = await repositoryUserDetail.GetAsync(
            new UserDetails {
                Id = userDetails.Id,
                RowNumber = userDetails.RowNumber
        });

        Assert.AreEqual(userDetail != null, true);
    }

    [TestMethod]
    public async Task AlterCustomEntityAsync()
    {
        var userDetails = new UserDetails { Id = "3442234344", RowNumber = 1, Description = "First Info" };
        
        await repositoryUserDetail.InsertAsync(userDetails);

        await ctx.SaveChangesAsync();

        var userDetailsEdit = new UserDetails {
            Id = userDetails.Id,
            RowNumber =  userDetails.RowNumber,
            Description = "Second Info"
        };

        await repositoryUserDetail.AlterAsync(userDetailsEdit);

        var userDetails1 = await repositoryUserDetail.GetAsync(userDetailsEdit);

        Assert.AreEqual(userDetails1.Description,"Second Info");
    }
}

public class RepositoryUserDetail : RepositoryCrudBaseAsync<UserDetails, string>
{
    public RepositoryUserDetail(DbContext context) : base(context)
    {
    }
}

