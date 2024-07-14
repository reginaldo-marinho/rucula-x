namespace RuculaX.Database.Query
{
    public class PaginationException : Exception
    {
        public const string OptionPagination = "Option pagination not exist"; 
        public PaginationException(string? message) : base(message)
        {
        }

        public PaginationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}