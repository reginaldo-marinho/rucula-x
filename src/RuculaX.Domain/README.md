# Ruculax Domain

Responsável pelo gerenciamento correto das Entidades e pela correta identificação para a camada Entity Framework.

## `Entity<T>`
Garante que a identidade da Entidade seja um `Id` do tipo `T`.

```c#
public class Sale : Entity<string> 
{
    public string? Seller { get; set; }    
    public string? Buyer { get; set; }    
}
```

## `ICustomEntity`
Presta suporte para que a identidade possa ter a quantidade necessária de propriedades. 

```c#
public class SaleDetailsEntity : Entity<string>, ICustomEntity
{
    public string CodeItem { get; set; } = "";   
}
```


