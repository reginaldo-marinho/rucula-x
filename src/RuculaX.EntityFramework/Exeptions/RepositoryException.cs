namespace RuculaX.EntityFramework;
public class RepositoryException : Exception
{
    public const string  DbSetNotFound = "DbSet {0} Not Found";
     
    public RepositoryException(string? message) : base(message)
    {
    }
    
    public RepositoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
