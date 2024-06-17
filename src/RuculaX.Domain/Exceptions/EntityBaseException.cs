namespace RuculaX.Domain;


public class EntityBaseException : Exception
{
    public const string TypeEntityNotExist = "Type Entity Not Exist";
    
    public EntityBaseException(string? message) : base(message)
    {
    }
    public EntityBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
