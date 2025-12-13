using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;

public class Sale : Entity<string> 
{
    public Sale(string id) :  base(id)
    {
    }
    
    public string? Seller { get; set; }    
    public string? Buyer { get; set; }    
}

public class SaleDetailsEntity : Entity<string>, ICustomEntity
{
    public SaleDetailsEntity(string id) : base(id)
    {
        
    }
    public string CodeItem { get; set; } = "";   
}


public class SaleDetails : SaleDetailsEntity
{
    public SaleDetails(string id) : base(id)
    {
        
    }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
