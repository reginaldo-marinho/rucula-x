namespace RuculaX.Database.Query;

public interface IQuery
{
    Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config);
}
