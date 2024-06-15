using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;

public abstract class RepositoryCudBaseAsync<TEntity,TIdentity,TType> : ICommandAsync<TEntity,TIdentity> where TEntity : Identity<TType>                                                                                                                                                              
{
    private DbSet<TEntity> DbSet;

    public  RepositoryCudBaseAsync(DbContext context)
    {
        DbSet = context.GetModel<TEntity,TType>(); 
    }

    public virtual async Task AlterAsync(TEntity input)
    {
        Type type = input.GetType();

        Type Identity = GetEntityBase(type);

        if(Identity?.FullName == typeof(Identity<TType>).FullName)
        {

        }
    }

    public  virtual async Task AlterAsync(TEntity input, TIdentity identity)
    {
    }

    public virtual async Task AlterAsync(TEntity input, Expression<Func<TEntity, bool>> predicate)
    {
        var result = await DbSet.FindAsync(predicate) ?? throw new RepositoryException(RepositoryException.ModelNotFound);
        var entity = DbSet.Entry(result);
        entity.CurrentValues.SetValues(input);
    }

    public virtual Task DeleteAsync(TEntity identity)
    {
        throw new NotImplementedException();
    }

    public  virtual Task DeleteAsync(TEntity input, TIdentity identity)
    {
        throw new NotImplementedException();
    }

    public async Task InsertAsync(TEntity input)
    {
        await DbSet.AddAsync(input);
    }

    public Type GetEntityBase(Type type)
    {
        if(type.BaseType?.FullName == typeof(Object).FullName)
        {
            throw new RepositoryException(string.Format(RepositoryException.ClassNotContainValidBaseClass,nameof(TEntity)));
        }

        if(type.BaseType?.FullName == typeof(Identity<TType>).FullName){
            return type.BaseType;
        }

        Type CustomEntity = type.GetInterface(nameof(ICustomEntity));

        if(CustomEntity is not null){
            return type;
        }

        return GetEntityBase(type.BaseType);
    }
}
