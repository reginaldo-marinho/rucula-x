namespace RuculaX.EntityFramework.Test;

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
    public async void InsertAsync()
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

