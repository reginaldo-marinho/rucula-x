using System.Linq.Expressions;

namespace Ruculax.Database.Common;

public interface ICommandAsync<TEntity,TIdentity>
{
    Task InsertAsync(TEntity input);   
    Task AlterAsync(TEntity input);   
    Task AlterAsync(TEntity input,TIdentity identity);  
    Task AlterAsync(TEntity input,Expression<Func<TEntity, bool>> predicate);  
    Task DeleteAsync(TEntity input);
    Task DeleteAsync(TEntity input,TIdentity identity);   
}


public interface ICommandDtoAsync<TEntityDto, TEntity, TIdentity>
{
    Task InsertAsync(TEntityDto inputDto);   
    Task AlterAsync(TEntityDto inputDto);   
    Task AlterAsync(TEntityDto inputDto,TIdentity identity);  
    Task AlterAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
    Task DeleteAsync(TEntityDto inputDto);
    Task DeleteAsync(TEntityDto inputDto,TIdentity identity);   
}


