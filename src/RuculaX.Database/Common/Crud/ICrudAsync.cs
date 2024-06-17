using System.Linq.Expressions;

namespace Ruculax.Database.Common.Crud;

public interface ICrudAsync<TEntity,TIdentity>
{
    Task InsertAsync(TEntity input);   
    Task AlterAsync(TEntity input);   
    Task AlterAsync(TEntity input,TIdentity identity);  
    Task AlterAsync(TEntity input,Expression<Func<TEntity, bool>> predicate);  
    Task DeleteAsync(TEntity input);
    Task DeleteAsync(TEntity input,TIdentity identity);   
}
