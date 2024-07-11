using RuculaX.Database;

namespace Ruculax.Database.Test;

public class QueriesDatabaseTest : Queries
{
    public QueriesDatabaseTest()
    {
        Set(nameof(User), typeof(UserQuery));
    }
}
