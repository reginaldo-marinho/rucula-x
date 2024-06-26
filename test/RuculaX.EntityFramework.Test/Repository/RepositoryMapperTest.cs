namespace RuculaX.EntityFramework.Test.Repository;

[TestClass]
public class RepositoryMapperTest
{
    TestContext ctx;
    
    MapperCrudRepository repositoryMapUserDetail;
    
    public RepositoryMapperTest()
    {
        ctx = DbInMemory.GetContext();
        
        repositoryMapUserDetail = new MapperCrudRepository(new RepositoryCrudBaseAsync<User,string>(ctx));
    }

    [TestMethod]
    public async Task InsertAsync()
    {
        var userDto = new UserDTo 
        {
            Id = "2121212", 
            Name = "Reginaldo"
        };

        await repositoryMapUserDetail.InsertAsync(userDto);
      
        await ctx.SaveChangesAsync();
    }
}

