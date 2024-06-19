using Microsoft.EntityFrameworkCore;

namespace RuculaX.EntityFramework.Test;

public class TestContext : DbContext
{       
    public TestContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<User> User { get;set;}
    public DbSet<UserDetails> UserDetails { get;set;}
}
