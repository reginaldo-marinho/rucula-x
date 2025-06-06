using System.Reflection;

namespace RuculaX.Database.Query;

/// <summary>
/// Create IPagedQuery instances
/// </summary>
/// <typeparam name="IConnection"></typeparam>
public class FactoryQuery<IConnection> : IQuery
{
    private IConnection _connection;
    private readonly IPagedQuery _queries;

    public FactoryQuery(IConnection connection, IPagedQuery queries)
    {
        _connection = connection;
        _queries = queries;
    }

    public async Task<QueryConfigurationOutput> QueryAsync(IQueryConfigurationInput input)
    {
        var typeQuery = _queries.Get(input.Name);

        ConstructorInfo constructor = typeQuery.GetConstructor(new Type[] {typeof(IConnection)});

        if(constructor is not null)
        {
            var @params = new object[]{_connection};

            IQuery query = (IQuery)constructor.Invoke(@params);
            return await query.QueryAsync(input);
        }

        throw new Exception($"{nameof(typeQuery)} {input.Name}  not exist!");
    }
}
