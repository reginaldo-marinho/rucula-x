using RuculaX.Database;

namespace Ruculax.Database.Test;

public class QueriesDatabase : Queries
{
    public QueriesDatabase()
    {
        Set(nameof(User), typeof(UserQuery));
    }
}
