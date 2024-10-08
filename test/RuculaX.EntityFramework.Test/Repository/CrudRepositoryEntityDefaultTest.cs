﻿using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Common.Crud;

namespace RuculaX.EntityFramework.Test;


[TestClass]
public class CrudRepositoryEntityDefaultTest
{
    TestContext ctx = DbInMemory.GetContext();
    RepositoryUser repositoryUser;
    public CrudRepositoryEntityDefaultTest()
    {
        repositoryUser = new (ctx);
    }

    [TestMethod]
    public async Task GetDefaultIdentityAsync()
    {
        const string userIDReginaldo = "328409809";
        
        await repositoryUser.InsertAsync(new User { Id = userIDReginaldo, Name = "Reginaldo"});

        await ctx.SaveChangesAsync();

        var user = await repositoryUser.GetAsync(new User { Id = userIDReginaldo});

        Assert.AreEqual(user != null, true);
    }

    [TestMethod]
    public async Task InsertAsync()
    {
        const string userIDLucas = "438917070498247";
        
        await repositoryUser.InsertAsync(new User { Id = userIDLucas, Name = "Lucas"});

        await ctx.SaveChangesAsync();

        var users = await repositoryUser.GetAsync(new User { Id = userIDLucas});

        Assert.AreEqual(users != null, true);
    }

    [TestMethod]
    public async Task AlterDefaultEntityAsync()
    {
        const string userIDLucasMarinho = "2351r545234t5423dv";

        await repositoryUser.InsertAsync(new User { Id = userIDLucasMarinho, Name = "Lucas", Addreass = new Addreass {
             Id = userIDLucasMarinho,
             CEP = ""
        }});

        await ctx.SaveChangesAsync();

        await repositoryUser.AlterAsync(new User { Id = userIDLucasMarinho}, new MapUserInAlter());

        var user = await repositoryUser.GetAsync(new User { Id = userIDLucasMarinho});

        Assert.AreEqual(user.Name,"Lucas Marinho");
        Assert.AreEqual(user.Addreass.CEP,"132333453");
    }

    [TestMethod]
    public async Task DeleteAsync()
    {
        const string userIDJorge = "432432243234342";

        await repositoryUser.InsertAsync(new User { Id = userIDJorge, Name = "Jorge"});

        await ctx.SaveChangesAsync();

        var user = await repositoryUser.GetAsync(new User { Id = userIDJorge});

        await repositoryUser.DeleteAsync(user);

        await ctx.SaveChangesAsync();

        await Assert.ThrowsExceptionAsync<InvalidOperationException>(async () => await repositoryUser.GetAsync(new User { Id = userIDJorge}));

    }
}

public class RepositoryUser : RepositoryCrudBaseAsync<User, string>
{
    public RepositoryUser(DbContext context) : base(context)
    {
    }
}

public class MapUserInAlter : IAlterMap<User>
{
  public User Map(User entity)
  {
        const string userIDLucasMarinho = "2351r545234t5423dv";

        var user =  new User { Id = userIDLucasMarinho, Name = "Lucas Marinho", Addreass = new Addreass {
            Id = userIDLucasMarinho,
            CEP = "132333453"
        }};

        entity.Id = user.Id;
        entity.Name = user.Name;
        entity.Addreass.Id = user.Addreass.Id;
        entity.Addreass.CEP = user.Addreass.CEP;

        return entity;
  }
}
