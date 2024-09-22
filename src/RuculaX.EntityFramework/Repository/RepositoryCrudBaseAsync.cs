using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Common.Crud;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;

public class RepositoryCrudBaseAsync<TEntity,TType> : ICrudAsync<TEntity>, IAlterMapAdpter<TEntity> where TEntity : Entity<TType> 
{
    public DbSet<TEntity> DbSet;

    public  RepositoryCrudBaseAsync(DbContext context)
    {
        DbSet = context.GetModel<TEntity,TType>() ?? throw new RepositoryException(RepositoryException.DbSetNotFound); 
    }

    public virtual async Task AlterAsync(TEntity input, IAlterMap<TEntity> map)
    {
        var result = await GetAsync(input);
        var resultMap =  map.Map(result);
        
        var hashResult =  result.GetHashCode();
        var hashMap =  resultMap.GetHashCode();
        
        if( hashResult != hashMap)
        {
            var message = string.Format(RepositoryException.ObjectHashNotEqualInMap,hashMap,hashResult);
            throw new RepositoryException(message);
        }

        await AlterAsync(resultMap);
    }

    public virtual async Task AlterAsync(TEntity input, Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException("AlterAsync not Implemented");
    }

    public async Task AlterAsync(TEntity input)
    {
        this.DbSet.Update(input);
    }

  public virtual async Task DeleteAsync(TEntity input)
    {
        var result = await GetAsync(input);
        DbSet.Remove(result);
    }

    public async Task DeleteAsync(TEntity input, Expression<Func<TEntity, bool>> predicate)
    {
        var result = await DbSet.FirstAsync(predicate);
        DbSet.Remove(result);
    }

    public async Task<TEntity> GetAsync(TEntity input, IQueryable<TEntity> dbSetConfigured = null,  CancellationToken cancellationToken = default)
    {
        dbSetConfigured ??= DbSet;
        var expression = input.CreateExpressionDefaultEntity<TEntity,TType>();
        var result = await dbSetConfigured.FirstAsync(expression,cancellationToken);
        return result;     
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, IQueryable<TEntity> dbSetConfigured = null, CancellationToken cancellationToken = default)
    {
        dbSetConfigured ??= DbSet;
        var result = await dbSetConfigured.FirstAsync(predicate,cancellationToken);
        return result;
    }

    public async Task InsertAsync(TEntity input)
    {
        await DbSet.AddAsync(input);
    }
}
