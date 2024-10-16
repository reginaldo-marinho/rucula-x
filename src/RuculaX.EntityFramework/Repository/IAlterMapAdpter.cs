namespace RuculaX.EntityFramework;

public interface IAlterMapAdpter<TEntity>
{
    Task AlterAsync(TEntity input, IAlterMap<TEntity> map, IQueryable<TEntity> dbSetConfigured = null);   
}
