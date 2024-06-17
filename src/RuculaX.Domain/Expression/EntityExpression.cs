using System.Linq.Expressions;
using System.Reflection;

namespace RuculaX.Domain;

///<summary>
/// Provides methods for creating Unique Identity expressions
///</summary>
public static class EntityExpression
{

    ///<summary>
    /// Creates an expression that looks for the Default Id of the Entity<T> base class
    ///</summary>
    ///<remarks>
    /// (c=> c.Id == "value")
    ///</remarks>
    public static Expression<Func<T, bool>> CreateExpressionDefaultEntity<T,TType>(this T input) where T: Entity<TType>
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "c");

        Expression left = Expression.Property(param,  nameof(input.Id));
        Expression right = Expression.Constant(input.Id);

        Expression body = Expression.Equal(left, right);

        var result =  Expression.Lambda<Func<T, bool>>(body, param);
        
        return result;
    }


    ///<summary>
    /// Creates an expression that searches for all properties that represent a custom Identity
    ///</summary>
    ///<remarks>
    /// (c=> c.Id == "value") && (c=> c.Propert == "value2") ...
    ///</remarks>
    public static Expression<Func<T, bool>> CreateExpressionEntity<T,TType>(this T input) where T: Entity<TType>
    {
        List<Expression>  bodys = new ();

        Type type = GetEntityBase<TType>(input);
        
        ParameterExpression param = Expression.Parameter(typeof(T), nameof(input));
        
        PropertyInfo[] properts  = type.GetProperties();

        for (int i = 0; i < properts.Length; i++)
        {
            PropertyInfo propert  = properts[i];

            Expression left = Expression.Property(param, propert.Name);
            
            var value =  propert.GetValue(input);
            Expression right = Expression.Constant(value);
            Expression body = Expression.Equal(left, right);
            
            if(properts.Length == 1)
            {
                var defaultExpression =  Expression.Lambda<Func<T, bool>>(body, param);
                return defaultExpression;
            }

            bodys.Add(body);
        }


        Expression expression = null;

        for (int i = 0; i < bodys.Count; i++)
        {
            if(i == 0){
                expression = bodys[0];
                continue;
            } 
            
            expression = Expression.And(expression!, bodys[i]);
        }

        var customExpression =  Expression.Lambda<Func<T, bool>>(expression!, param);
        
        return customExpression;
    }

    public static Type GetEntityBase<TType>(object obj)
    {
        Type type= obj.GetType();
        
        if(type.BaseType?.FullName == typeof(Object).FullName)
        {
            throw new EntityBaseException(EntityBaseException.TypeEntityNotExist);
        }

        if(type.BaseType?.FullName == typeof(Entity<TType>).FullName){
            return type.BaseType;
        }

        Type CustomEntity = type.BaseType.GetInterface(nameof(ICustomEntity));

        if(CustomEntity is not null){
            return type.BaseType;
        }

        return GetEntityBase<TType>(type.BaseType);
    }

}
