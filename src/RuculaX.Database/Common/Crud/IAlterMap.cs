namespace RuculaX.Database.Common.Crud
{
    public interface IAlterMap<TEntity>
    {
        public TEntity Map(TEntity entity);
    }
}