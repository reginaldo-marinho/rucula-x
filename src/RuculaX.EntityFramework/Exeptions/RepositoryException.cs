namespace RuculaX.EntityFramework;
public class RepositoryException : Exception
{
    public const string  DbSetNotFound = "DbSet {0} Not Found";
    public const string  ModelNotFound = "{0} Model Not Found";
    public const string  EntityNotFound = "{0} Not Found";
    public const string  ClassNotContainValidBaseClass = "{0} Not contain valid base class";
 
    public RepositoryException(string? message) : base(message)
    {
    }
    
    public RepositoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
