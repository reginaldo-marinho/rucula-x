namespace RuculaX.Database;

public interface IQuery
{
    Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config);
}
