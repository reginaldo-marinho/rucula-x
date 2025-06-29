namespace RuculaX.Domain;


public class RuculaxEntityBaseException : Exception
{
    public const string TypeEntityNotExist = "Type Entity Not Exist";
    public const string AlreadyHasAnIdentity = "The Entity Already Has an Identity";
    
    public RuculaxEntityBaseException(string? message) : base(message)
    {
    }
    public RuculaxEntityBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
