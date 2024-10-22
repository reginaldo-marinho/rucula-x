namespace RuculaX.Domain;

/// <summary>
/// Indicates that the Entity Has a Unique Identifier
/// </summary>
/// <typeparam name="T"></typeparam>
public class Entity<T>
{
    public T? Id {get;set;}   
    
}
/// <summary>
/// For Entities that have more than one field in the composition of their unique identity
/// </summary>
public interface ICustomEntity
{

}
