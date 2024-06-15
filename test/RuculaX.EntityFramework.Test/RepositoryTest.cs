using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.Extensions;
using RuculaX.Domain;
using RuculaX.EntityFramework;

[TestClass]
public class RepositoryTest
{
    [TestMethod]
    public void ThrowModelDbSetExceptionIfInformedEntityDoesNotExistInCurrentRepository()
    {
        // Action act = () =>  new RepositoryCudAsync<UserModelDetail,string>(new ContextTest());

        // Assert.ThrowsException<RepositoryException>(act);
    }
}
public class ContextTest : DbContext
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("TestDb");
    }
    public DbSet<UserModel> userModels {get;set;}
    public DbSet<UserModelDetail> UserModelDetails {get;set;}
    
}

class EntityDetail : Entity<string> , ICustomEntity {
    public int RowNumber {get;set;}
}

public class UserModel : Entity<string> 
{

}

public class UserModelEntity : Entity<string> , ICustomEntity {
    public int Number { get; set; }
}


public class UserModelDetail : UserModelEntity
{

}
