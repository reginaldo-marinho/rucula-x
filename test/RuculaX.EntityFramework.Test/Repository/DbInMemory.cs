using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace RuculaX.EntityFramework.Test;

public class DbInMemory
{
    public static TestContext CreateContextTest ()
    {
            DbContextOptionsBuilder _contextOptions = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase("TesteInMemory")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                
            var Context = new TestContext(_contextOptions.Options);

                InitDb(ref Context);

        return Context;
    }

    private static void InitDb(ref TestContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.User.AddRange(
            new User("123") { Name = "Reginaldo",
            Addreass = new Addreass {
                 Id="123",
                 CEP = "Cep Reginaldo"
            } },
            new User("456") { Name = "Raquel",
            Addreass = new Addreass {
                 Id="456",
                 CEP = "Cep Raquel"
            } },
            new User("789") { Name = "Nathalia",
            Addreass = new Addreass {
                 Id="789",
                 CEP = "Cep Nathalia"
            } });


        context.UserDetails.AddRange(
            new UserDetails ("123"){ RowNumber = 1 },
            new UserDetails ("456"){ RowNumber = 2 },
            new UserDetails ("789"){ RowNumber = 3 });
            
        context.SaveChanges();
    }
}



