namespace RuculaX.EntityFramework;

public interface IAlterMap<TEntity>
{
    public TEntity Map(TEntity entity);
}
