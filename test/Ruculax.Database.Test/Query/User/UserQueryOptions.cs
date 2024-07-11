namespace Ruculax.Database.Test
{
    public class UserQueryOptions
    {
        public UserQueryOptions(int lastId)
        {
            LastId = lastId;
        }
        public int LastId { get; private set; } = 0;
    }
}