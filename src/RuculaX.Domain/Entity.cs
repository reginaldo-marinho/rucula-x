namespace RuculaX.Domain;

/// <summary>
/// Provides an Identification for a Data Transfer Object
/// </summary>
public interface IEntityDto
{   
}

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
