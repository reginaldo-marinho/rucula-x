using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;

public class Sale : Entity<string> 
{
    public string? Seller { get; set; }    
    public string? Buyer { get; set; }    
}

public class SaleDetailsEntity : Entity<string>, ICustomEntity
{
    public string CodeItem { get; set; } = "";   
}


public class SaleDetails : SaleDetailsEntity
{
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
