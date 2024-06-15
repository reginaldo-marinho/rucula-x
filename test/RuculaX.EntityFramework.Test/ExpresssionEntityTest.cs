using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;

public class TestEntity : Entity<string> {
    public string? Nome { get; set; }    
}

[TestClass]
public class ExpresssionEntityTest
{
    List<TestEntity> users = new () {
        new TestEntity { Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4", Nome = "Reginaldo" },
        new TestEntity { Id = "9ecb8337-51e5-4970-a690-a7cb943c3abd", Nome = "Raquel" },
        new TestEntity { Id = "268b9df3-97e4-4a3d-97a2-8ed01480a7f7", Nome = "Júlia" }
    };
    

    [TestMethod]
    public void GetUserBasedOnDefaultId(){
        
        var userReginaldo = new TestEntity()
        {
            Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4" 
        };
        
        var expression = userReginaldo.CreateExpressionDefaultEntity<TestEntity,string>();

        var user = users.FirstOrDefault(expression);

        Assert.IsTrue(user != null);
    }
}

