using RuculaX.Domain;

namespace RuculaX.EntityFramework.Test;


[TestClass]
public class ExpresssionEntityTest
{
    readonly List<Sale> sales = [
        new Sale { Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4", Seller = "Reginaldo", Buyer = "Raquel"},
        new Sale { Id = "9ecb8337-51e5-4970-a690-a7cb943c3abd", Seller = "Reginaldo", Buyer = "Léonardo"},
        new Sale { Id = "268b9df3-97e4-4a3d-97a2-8ed01480a7f7", Seller = "Reginaldo", Buyer = "Pedro"}
    ];

    readonly List<SaleDetails> salesFromRaquel = [
        new SaleDetails { Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4", CodeItem = "123", Description = "Coke" },
        new SaleDetails { Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4", CodeItem = "456", Description = "Cheese" },
        new SaleDetails { Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4", CodeItem = "789", Description = "TNT Energy" }
    ];

    [TestMethod]
    public void GetSaleAfterGettingStandardExpressionObtainedFromEntityEntity()
    {
        
        var sale = new Sale()
        {
            Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4" 
        };
        
        var expression = sale.CreateExpressionDefaultEntity<Sale,string>();

        var user = sales.FirstOrDefault(expression);

        Assert.IsTrue(user != null);
    }

    [TestMethod]
    public void GetSaleAfterGettingCustomExpressionObtainedFromICustomEntityInterface()
    {
        
        var saleDetail = new SaleDetails()
        {
            Id = "39656e18-3f84-4be0-a5d0-a60c77c3e5b4",
            CodeItem = "789"
        };

        var expression = saleDetail.CreateExpressionEntity<SaleDetails,string>();

        var resultSaleDetail = salesFromRaquel.FirstOrDefault(expression);

        Assert.IsTrue(resultSaleDetail != null);
    }
}

