# Ruculax.Database
Fornece suporte para camada de acesso a dados.

## Query Paginada
Fornece serviço para criação de queries paginadas. Isso garante que diversas consultas criadas, possam ser utilizadas em inumeras localidades dentro de uma aplicação.

### Implementação

#### Crie sua Classe 

Crie uma classe que herde de `IQuery` e passe no seu construtor o tipo de conexão que a fabrica deverá passar como argumento

```C#

public class UserQuery : IQuery
{
    ApplicationContext _context;

    public UserQuery(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        var output = new QueryConfigurationOutput(){};
        return output;
    }
}
```
>> Esse tipo de implementação força o desenvolvedor a gerenciar a paginação com base na sua lógica. Isso não é tão complicado, visto que em `IQueryConfigurationInput` fornece a propriedade `Page`, entretando poderia ficar mais simples, vejamos...


#### Trabalhando com Factory Method
Além de herdar de  `IQuery`, também podemos herdar de `PaginationAsync`, isso ajuda a separar corretamente a lógica da paginação.

>> Ao herdar você será obrigado a implemetar os métodos abstratos. Suas opções referem-se à **first, last, previous, next e contain**.

```c#

public class UserQuery : PaginationAsync, IQuery
{
   ApplicationContext _context;

    public UserQuery(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        // Deixe exatamente do modo em que está
        var output = await QueryAsync(config.Page,config); 
        return output;
    }

    protected async override Task<IQueryConfigurationOutput> FirstAsync(IQueryConfigurationInput config)
    {
        ...
    }

    protected async override Task<IQueryConfigurationOutput> LastAsync(IQueryConfigurationInput config)
    {
        ...
    }

    protected override async Task<IQueryConfigurationOutput> NextAsync(IQueryConfigurationInput config)
    {
        ...
    }

    protected async override Task<IQueryConfigurationOutput> PreviousAsync(IQueryConfigurationInput config)
    {
        ...
    }
    protected async override Task<IQueryConfigurationOutput> ContainAsync(IQueryConfigurationInput config)
    {
        ...
    }
}
```
#### Adicione suas `Queries`

Queries é uma classe abstrata que disponibiliza um método `set` e um `get`, seu objetivo principal é gerenciar as queries e suas identificações.

>> Por se tratar de classe abstrata, você deve herda-la.

```
public class QueriesDatabaseTest : Queries
{
    public QueriesDatabaseTest()
    {
        Set(nameof(User), typeof(UserQuery));
        Set("Cliente", typeof(ClienteQuery));
        Set("eq2-3qq", typeof(ProdutosQuery));
    }
}
```
>> Notem que aqui estamos amarrando "User" (nameof) com a query UserQuery(typeof)

#### As Configurações Input e Output

Ao desejar criar uma query, informamos antes algumas configurações de entrada `IQueryConfigurationInput`, configurações que ajudarão a identificar o tipo desejado.


Apos a criação da query, retornamos o set de dados, juntamente com as configurações de saida `IQueryConfigurationOutput`

#### Options

Options é uma propriedade que guarda opções especificas para a query desejada, ela está presente tanto em input `IQueryConfigurationInput` quanto em output `IQueryConfigurationOutput`, seu tipo `string` é útil porque passamos por aqui as configurações especificas de cada query com um tipo que pode ser convertido internamente.

```
public class UserQueryOptions
{
    public int LastId { get; set } = 0;
}
```

Acima vemos um objeto de valor `UserQueryOptions` que guarda o ultimo Id de um Usuário

>> Essa propriedade é quem da a flexibilidade necessária nas queries criadas, isso ocorre porque cada query tem suas particularidades, logo, isso deve ser o mais flexivel possível.

Vejamos um exemplo

```
var userPageOne = new QueryConfigurationInput()
{
    Name = nameof(User),
    Options = "{\"LastId\": 0}"
};
```
> Notem que a representação `string` equivale ao objeto do tipo `UserQueryOptions`

#### Adicione o Serviço
```C#
builder.Services.AddSingleton<IQueries,RuculaUpQueries>();
builder.Services.AddScoped<FactoryQuery<ApplicationContext>>();

```


#### Consumindo a Querie

```C#
[ApiController]
[Route("[controller]")]
public class QueryController : ControllerBase
{
    private readonly FactoryQuery<ApplicationContext> _query;
    public QueryController(FactoryQuery<ApplicationContext> query)
    {
        _query = query;
    }

    [HttpPost]
    public Task<IQueryConfigurationOutput> Post(QueryConfigurationInput configuration)
    {
        return _query.QueryAsync(configuration);
    }
}
```

## WhereIf
Use esse método de extensão para logica condicional dentro das **Queries**.