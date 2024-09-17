using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;


public class User : Entity<string> 
{
    public string? Name { get; set; }    
    public Addreass Addreass { get; set; }
}
public class Addreass {
    public string Id { get; set;}
    public string CEP { get; set;}
}
public class UserDetailsEntity : Entity<string>, ICustomEntity
{
    public int RowNumber { get; set; }  
}


public class UserDetails : UserDetailsEntity
{
    public string? Description { get; set; }
}


public class UserDTo : Entity<string>, IEntityDto
{
    public string? Name { get; set; }    
}
