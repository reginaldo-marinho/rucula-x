using System.Linq.Expressions;
using RuculaX.Domain;

namespace RuculaX.EntityFramework;

///<summary>
/// Provides methods for creating Unique Identity expressions
///</summary>
public static class EntityExpression
{

    ///<summary>
    /// Creates an expression that searches for an Identity using the Standard Id
    ///</summary>
    ///<remarks>
    /// (c=> c.Id == "value")
    ///</remarks>
    public static Func<T, bool> CreateExpressionDefaultEntity<T,TType>(this T input) where T: Entity<TType>
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "c");

        Expression left = Expression.Property(param,  nameof(input.Id));
        Expression right = Expression.Constant(input.Id);

        Expression body = Expression.Equal(left, right);

        var result =  Expression.Lambda<Func<T, bool>>(body, param);
        
        return result.Compile();
    }
}
