using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace RuculaX.EntityFramework.Test;

public class DbInMemory
{
    private static TestContext Context = null;

    public static TestContext GetContext ()
    {
        if(Context == null){
            DbContextOptionsBuilder _contextOptions = new DbContextOptionsBuilder<TestContext>()
                .UseInMemoryDatabase("TesteInMemory")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                
            Context = new TestContext(_contextOptions.Options);

                InitDb();
        }

        return Context;
    }

    private static void InitDb()
    {
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();

        Context.User.AddRange(
            new User { Name = "Reginaldo", Id = "123",
            Addreass = new Addreass {
                 Id="123",
                 CEP = "Cep Reginaldo"
            } },
            new User { Name = "Raquel",Id = "456",
            Addreass = new Addreass {
                 Id="456",
                 CEP = "Cep Raquel"
            } },
            new User { Name = "Nathalia",Id = "789",
            Addreass = new Addreass {
                 Id="789",
                 CEP = "Cep Nathalia"
            } });


        Context.UserDetails.AddRange(
            new UserDetails { Id = "123", RowNumber = 1 },
            new UserDetails { Id = "456", RowNumber = 2 },
            new UserDetails { Id = "789", RowNumber = 3 });
            
        Context.SaveChanges();
    }
}



