using System.Linq.Expressions;
using RuculaX.Database.Common.Crud;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;
public abstract class  RepositoryCrudMApAsync<TEntity, TentityDto, TType> : ICrudDtoAsync<TentityDto,TEntity>
        where TEntity : Entity<TType>
        where TentityDto : IEntityDto
{
    protected RepositoryCrudBaseAsync<TEntity,TType> Repository;
    public RepositoryCrudMApAsync(RepositoryCrudBaseAsync<TEntity,TType> repository)
    {
        Repository = repository;
    }
    
    public abstract Task InsertAsync(TentityDto inputDto);
    public abstract Task AlterAsync(TentityDto inputDto);
    public abstract Task AlterAsync(TentityDto inputDto, Expression<Func<TEntity, bool>> predicate);
    public abstract Task DeleteAsync(TentityDto identityDto);
    public abstract Task DeleteAsync(TentityDto inputDto, Expression<Func<TEntity, bool>> predicate);
    public abstract Task<TentityDto> GetAsync(TEntity input, IQueryable<TEntity> dbSetConfigured = null, CancellationToken token = default);
    public abstract Task<TentityDto> GetAsync(Expression<Func<TEntity, bool>> predicate, IQueryable<TEntity> dbSetConfigured = null, CancellationToken token = default);
}


