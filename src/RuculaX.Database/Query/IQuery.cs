namespace RuculaX.Database.Query;

public interface IQuery
{
    Task<QueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config);
}
