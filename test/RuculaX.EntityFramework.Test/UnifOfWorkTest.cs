using Microsoft.EntityFrameworkCore;

namespace RuculaX.EntityFramework.Test;

[TestClass]
public class UnifOfWorkTest
{

    [TestMethod]
    public async Task ExecCommandAsync()
    {

        var ctx = DbInMemory.GetContext();

        RepositoryUser user = new (ctx);
        RepositoryUserDetail userDetail = new (ctx);

        using var uow = new UnitOfWorkAsync(ctx);
        
        await uow.BeginAsync();

        await user.InsertAsync(new User {
                Id = "cwocwpcwpowcjowc",
                Name = "Reginaldo",
        });
        await uow.SaveChangesAsync();

        await userDetail.InsertAsync(new UserDetails {
                Id = "cwocwpcwpowcjowc",
                RowNumber = 22,
                Description = "Test"
        });
        
        await uow.SaveChangesAsync();
        
        await uow.CommitAsync();

        var result = await ctx.UserDetails.FirstAsync(c => c.Id == "cwocwpcwpowcjowc");
    }
    
}
