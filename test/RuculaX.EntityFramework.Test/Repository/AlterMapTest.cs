using RuculaX.Database.Common.Crud;

namespace RuculaX.EntityFramework.Test.Repository
{
    [TestClass]
    public class AlterMapTest
    {
        TestContext ctx = DbInMemory.GetContext();
        RepositoryUser repositoryUser;
        public AlterMapTest()
        {
            repositoryUser = new (ctx);
        }

        [TestMethod]    
        public async Task ThrowExceptionWhenReturnedInstanceIsDifferentFromInputInstanceAsync()
        {
            const string userIDLucasMarinho = "2351r545234t5423dv";

            await repositoryUser.InsertAsync(new User { Id = userIDLucasMarinho, Name = "Lucas", Addreass = new Addreass {
                Id = userIDLucasMarinho,
                CEP = ""
            }});

            await ctx.SaveChangesAsync();

            await Assert.ThrowsExceptionAsync<RepositoryException>(async () => 
                await repositoryUser.AlterAsync(new User { Id = userIDLucasMarinho}, new MapUserTest())
            );
        }
    }

        
    public class MapUserTest : IAlterMap<User>
    {
        public User Map(User entity)
        {
            const string userIDLucasMarinho = "2351r545234t5423dv";

            var user =  new User { Id = userIDLucasMarinho, Name = "Lucas Marinho", 
                Addreass = new Addreass 
                {
                    Id = userIDLucasMarinho,
                    CEP = "132333453"
                }
            };

            entity.Id = user.Id;
            entity.Name = user.Name;
            entity.Addreass.Id = user.Addreass.Id;
            entity.Addreass.CEP = user.Addreass.CEP;

            return user;
        }
    }
}


