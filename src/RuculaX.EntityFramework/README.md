<p align="center">
    <img src="../../Ruculax.png" style="width:200px">
    <h1 align="center"> Ruculax Entity Framework</h1>
</p>

<p align="center">
  <a href="https://circleci.com/gh/angular/workflows/angular/tree/main">
    <img src="https://img.shields.io/badge/license-MIT-blue" alt="License" />
  </a>&nbsp;
  <a href="https://www.nuget.org/packages/RuculaX.EntityFramework/">
    <img src="https://img.shields.io/nuget/v/RuculaX.EntityFramework" alt="Version RuculaX Entity Framewrok" />
  </a>&nbsp;
  <a href="https://github.com/reginaldo-marinho/rucula-x/graphs/contributors">
    <img src="https://img.shields.io/github/contributors/reginaldo-marinho/rucula-x" alt="Discord conversation" />
  </a>
   <a href="https://github.com/reginaldo-marinho/rucula-x/commits/main">
    <img src="https://img.shields.io/github/last-commit/reginaldo-marinho/rucula-x" alt="Discord conversation" />
  </a>

   <a href="https://www.nuget.org/packages/RuculaX.EntityFramework/">
    <img src="https://img.shields.io/nuget/dt/RuculaX.EntityFramework" alt="Discord conversation" />
  </a>
</p>

## Criando Repositório

Se você deseja criar repositórios consistentes, com muita pouca linha de codigo, esse projeto é para você. 

Aqui substituimos dezenas de interfaces por uma unica classe base, o que garante facilidade na suas utilização!

```
// Simplesmente assim
public class RepositorySale : RepositoryCrudBaseAsync<Sale, string>
{
    public RepositorySale(DbContext context) : base(context)
    {
    }
}
```

###  Garanta que seus Modelos sejam Entidades

As Entidades simplesmente representam a Primary Key do Modelo, o que pode ser simples ou composta.

#### Entity

`Entity<T>` representa uma Entidade com uma propriedade Id do tipo T, use esse tipo quando você sabe que sua representação SQL terá somente um campo Primary key.

```c#
public class Sale : Entity<string>
{
    public string? Seller { get; set; }    
    public string? Buyer { get; set; }    
}
```
```sql
-- Representação SQL
CREATE TABLE Sale (
    Id NVARCHAR(50) PRIMARY KEY,
    Seller NVARCHAR(255) NULL,
    Buyer NVARCHAR(255) NULL
);
```


#### ICustomEntity

`ICustomEntity` é usado quando queremos representar uma Primary Key composta. Essa interface é usada juntamente com o `Entity<T>`.


```c#
public class SaleDetailsEntity : Entity<string>, ICustomEntity 
{
    public string CodeItem { get; set; } = "";   
}
```
> Note que ainda estamos trabalhando com a Primary Key

Agora vamos criar nosso Modelo

```c#
public class SaleDetails : SaleDetailsEntity
{
    public string? Description { get; set; }
    public decimal? Price { get; set; }
}
```
```sql
-- Representação SQL
CREATE TABLE SaleDetails (
    Id NVARCHAR(50) NOT NULL,
    CodeItem NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL,
    Price DECIMAL(18, 2) NULL,
    PRIMARY KEY (Id, CodeItem)
);
```


Com esses dois tipos de configuração de Entidade nos nossos modelos, o Ruculax Entity Framework será capaz de prestar suporte à operações CRUD.

### Herde da Classe base RepositoryCrudBaseAsync

As operações CRUD já existe, o que resta agora é você fazer bom uso da herança, veja como é simples.


```
public class RepositorySale : RepositoryCrudBaseAsync<SaleDetails, string>
{
    public RepositorySale(DbContext context) : base(context)
    {
    }
}
```

### As Operações

####  InsertAsync 

```c#
    var sale = new Sale { Id = "324909340", Seller = "reginaldo-marinho", Buyer = "rucula-js" };
    await repositorySale.InsertAsync(sale);
```
####  GetAsync

Informe somente as propriedades que representam a Primary Key

```c#
    var sale = await repositorySale.GetAsync(new Sale { Id = "324909340"});
```

####  AlterAsync

Antes de trabalharmos com AlterAsync, precisamos conhecer a interface `IAlterMap<T>`, com ela, você tem segurança para alterar somente o que você deseja.


```c#
public class AlterSale : IAlterMap<Sale>
{
    private AlterSaleDto SaleDto;

    puclic AlterSale(AlterSaleDto saleDto){
        SaleDto = saleDto;
    }

    public Sale Map(Sale entity)
    {
        entity.Seller = saleDto.Seller;
        entity.Buyer = saleDto.Buyer;
        return entity;
    }
}
```

```c#
public class SaleAlterBuyer : IAlterMap<Sale>
{

    private string Buyer;

    puclic SaleAlterBuyer(string buyer){
        Buyer = buyer;
    }

    public Sale Map(Sale entity)
    {
        entity.Seller = Buyer;
        return entity;
    }
}
```

> **Aviso: Não tente criar outra entidade e retorna-la, o ruculax irá checar seu hash o que gerará exceção caso seja diferente.**


```c#
    await repositorySale.AlterAsync(new Sale { Id = "324909340"}, new AlterSale());
```
>   **Observe que Sale contém somente a propriedade que representa a Primary Key, isso porque internamente  será feita uma leitura e retornado o registro para IAlterMap<T>**



####  DeleteAsync
Informe somente as propriedades que representam a Primary Key
```c#
    var sale = new Sale { Id = "324909340"}
    await repositorySale.DeleteAsync(sale);
```

## Trabalhando com a Unidade Lógica de Trabalho

## UnitOfWorkAsync
`UnitOfWorkAsync` é uma classe que por padrão recebe um `dbContext` via construtor e posteriormente fornece os métodos de transação para seus clientes.

> Para que tudo faça sentido, atente-se ao ciclo de [vida do contexto](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#implicitly-sharing-dbcontext-instances-via-dependency-injection), que por padrão é **scoped**.