namespace RuculaX.Domain;

/// <summary>
/// Indicates that the Entity Has a Unique Identifier
/// </summary>
/// <typeparam name="T"></typeparam>
public class Entity<T>
{
    public Entity() { }
    public Entity(T id)
    {
        this.Id = id;
    }

    public T? Id { get; private set; }
    public void SetId(T id) {
        CheckId(id);
        Id = id;
    }
    
    public void CheckId(T id)
    {
        if (id is not null)
        {
            throw new RuculaxEntityBaseException(RuculaxEntityBaseException.AlreadyHasAnIdentity);
        }
    }
}
/// <summary>
/// For Entities that have more than one field in the composition of their unique identity
/// </summary>
public interface ICustomEntity
{

}
