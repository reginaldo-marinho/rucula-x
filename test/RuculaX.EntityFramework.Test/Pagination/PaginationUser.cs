using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Common;
using RuculaX.Database.Query;
using RuculaX.EntityFramework.Pagination;

namespace RuculaX.EntityFramework.Test.Pagination;

public sealed class PaginationUser : QueryBase<User, UserRecordSnapshot, UserResultDto>
{
    public PaginationUser(DbContext context) : base(context)
    {
    }
    protected override Expression<Func<User, UserResultDto>> Columns() => (model) => new() { Id = model.Id, Name = model.Name };

     protected override IQueryable<User> Where(IQueryable<User> model, byte page, FirstAndLastRecordSnapshot<UserRecordSnapshot> snapshot, string text) => model
        .WhereIf(page == (byte)OptionPagination.Next, c => c.Id.CompareTo(snapshot.Last.Id) > 0)
        .WhereIf(page == (byte)OptionPagination.Previous, c => c.Id.CompareTo(snapshot.First.Id) < 0)
        .WhereIf(text.Length > 0, c => c.Name.Contains(text) || c.Id.Contains(text));  
        
    protected override IOrderedQueryable<User> OrderByAsc(IQueryable<User> model) => model
        .OrderBy(c => c.Id)
        .ThenBy(c => c.Name);
    protected override IOrderedQueryable<User> OrderByDesc(IQueryable<User> model) => model
        .OrderByDescending(c => c.Id)
        .ThenByDescending(c => c.Name);     

    protected override UserRecordSnapshot RecordSnapshot(UserResultDto? model) => new() { Id = model.Id };
}

