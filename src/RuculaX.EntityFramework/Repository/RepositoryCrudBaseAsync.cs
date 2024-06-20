using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common.Crud;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;

public class RepositoryCrudBaseAsync<TEntity,TType> : ICrudAsync<TEntity> where TEntity : Entity<TType>                                                                                                                                                              
{
    private DbSet<TEntity> DbSet;

    public  RepositoryCrudBaseAsync(DbContext context)
    {
        DbSet = context.GetModel<TEntity,TType>(); 
    }

    public virtual async Task AlterAsync(TEntity input)
    {
        var result = await GetAsync(input);
        var entity = DbSet.Entry(result);
        entity.CurrentValues.SetValues(input);
    }

    public virtual async Task AlterAsync(TEntity input, Expression<Func<TEntity, bool>> predicate)
    {
        var result = await GetAsync(input);
        var entity = DbSet.Entry(result);
        entity.CurrentValues.SetValues(input);
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

    public async Task<TEntity> GetAsync(TEntity input, CancellationToken cancellationToken = default)
    {
        var expression = input.CreateExpressionDefaultEntity<TEntity,TType>();
        var result = await DbSet.FirstAsync(expression,cancellationToken);
        return result;     
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await DbSet.FirstAsync(predicate,cancellationToken);
        return result;
    }

    public async Task InsertAsync(TEntity input)
    {
        await DbSet.AddAsync(input);
    }
}
