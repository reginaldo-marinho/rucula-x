using System.Linq.Expressions;
using System.Reflection.Metadata;
using RuculaX.Database.Common.Crud;

namespace Ruculax.Database.Common.Crud;
/// <summary>
/// Contract for a CRUD repository for a Single Entity
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface ICrudAsync<TEntity>
{
    Task InsertAsync(TEntity input);   
    Task AlterAsync(TEntity input, IAlterMap<TEntity> map);   
    Task AlterAsync(TEntity input,Expression<Func<TEntity, bool>> predicate);  
    Task DeleteAsync(TEntity input);
    Task DeleteAsync(TEntity input,Expression<Func<TEntity, bool>> predicate);  
    Task<TEntity> GetAsync(TEntity input, IQueryable<TEntity> dbSetConfigured = null, CancellationToken token = default);  
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, IQueryable<TEntity> dbSetConfigured = null, CancellationToken token = default);       
}