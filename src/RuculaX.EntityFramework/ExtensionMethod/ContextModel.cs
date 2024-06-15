using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;

public static class ContextModel
{
    public static  DbSet<TEntity>? GetModel<TEntity,TType>(this DbContext obj) where TEntity:Identity<TType>
    {
        Type type = obj.GetType();

        var nameEntity = typeof(TEntity).Name;

        PropertyInfo? propert = type.GetProperties()
        .Where(prop => prop.PropertyType == typeof(DbSet<TEntity>))
        .FirstOrDefault() ?? throw new RepositoryException(RepositoryException.DbSetNotFound);
        
        var DbSet =  (DbSet<TEntity>)propert?.GetValue(obj);

        return DbSet;

    }
}
