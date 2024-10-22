<p align="center">
    <img src="../../Ruculax.png" style="width:200px">
    <h1 align="center"> Ruculax Domain</h1>
    <span>Responsável pelo gerenciamento correto das Entidades e pela correta identificação para a camada Entity Framework.
    </span>    
</p>

<p align="center">
  <a href="https://circleci.com/gh/angular/workflows/angular/tree/main">
    <img src="https://img.shields.io/badge/license-MIT-blue" alt="License" />
  </a>&nbsp;
  <a href="https://www.nuget.org/packages/RuculaX.Domain/">
    <img src="https://img.shields.io/nuget/v/RuculaX.Domain" alt="Version RuculaX Entity Framewrok" />
  </a>&nbsp;
  <a href="https://github.com/reginaldo-marinho/rucula-x/graphs/contributors">
    <img src="https://img.shields.io/github/contributors/reginaldo-marinho/rucula-x" alt="Discord conversation" />
  </a>
   <a href="https://github.com/reginaldo-marinho/rucula-x/commits/main">
    <img src="https://img.shields.io/github/last-commit/reginaldo-marinho/rucula-x" alt="Discord conversation" />
  </a>

   <a href="https://www.nuget.org/packages/RuculaX.Domain/">
    <img src="https://img.shields.io/nuget/dt/RuculaX.Domain" alt="Discord conversation" />
  </a>
</p>


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


