using RuculaX.Database.Query;

namespace RuculaX.EntityFramework.Test.Pagination;

public class QueriesDatabase : PagedQuery
{
    public QueriesDatabase()
    {
        Set(nameof(PaginationUser), typeof(PaginationUser));
    }

}
