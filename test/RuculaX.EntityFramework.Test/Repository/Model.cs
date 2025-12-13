using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;


public class User : Entity<string> 
{
    public User(string id) : base(id)
    {
        
    }
    
    public string? Name { get; set; }    
    public Addreass Addreass { get; set; }
}
public class Addreass {
    public string Id { get; set;}
    public string CEP { get; set;}
}
public class UserDetailsEntity : Entity<string>, ICustomEntity
{
    public UserDetailsEntity(string id) : base(id) { }
    
    public int RowNumber { get; set; }  
}


public class UserDetails : UserDetailsEntity
{
    public UserDetails(string id) : base(id) { }
    public string? Description { get; set; }
}
