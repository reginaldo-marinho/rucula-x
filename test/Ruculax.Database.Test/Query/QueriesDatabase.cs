using RuculaX.Database.Query;

namespace Ruculax.Database.Test;

public class QueriesDatabase : PagedQuery
{
    public QueriesDatabase()
    {
        Set(nameof(User), typeof(UserQuery));
    }
}
