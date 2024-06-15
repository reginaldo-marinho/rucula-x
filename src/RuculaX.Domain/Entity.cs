namespace RuculaX.Domain;

public abstract class Identity<T> 
{
    public T? Id {get;set;}   
}

public class Entity<T> : Identity<T>
{
    
}
public interface ICustomEntity
{

}
