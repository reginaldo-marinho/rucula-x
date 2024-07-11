using System.Reflection;

namespace RuculaX.Database;

/// <summary>
/// Create IQuery instances
/// </summary>
/// <typeparam name="IConnection"></typeparam>
public class FactoryQuery<IConnection> : IQuery
{
    private IConnection _connection;
    private readonly IQueries _queries;

    public FactoryQuery(IConnection connection, IQueries queries)
    {
        _connection = connection;
        _queries = queries;
    }
    
    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        var typeQuery = _queries.Get(config.Name);

        ConstructorInfo constructor = typeQuery.GetConstructor(new Type[] {typeof(IConnection)});
        
        if(constructor is not null)
        {
            var @params = new object[]{_connection};
            
            IQuery query = (IQuery)constructor.Invoke(@params);
            return await query.QueryAsync(config);
        }
        
        throw new Exception($"{nameof(typeQuery)} {config.Name}  not exist!");
    }
}