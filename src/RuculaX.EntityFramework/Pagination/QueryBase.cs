using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Query;

namespace RuculaX.EntityFramework.Pagination;

/// <summary>
/// Abstract class for working with pagination
/// </summary>
/// <typeparam name="TModel">Type of model entity framework</typeparam>
/// <typeparam name="TRecordSnapshot">Type of record that serves to indicate information to the client that is transported from the client to the server and vice versa</typeparam>
/// <typeparam name="TResult">Type of record that will be returned</typeparam>
public abstract class QueryBase<TModel, TRecordSnapshot, TResult> : PaginationAsync<TResult>, IQuery where TModel : class
{
    private DbSet<TModel> _model;
    private FirstAndLastRecordSnapshot<TRecordSnapshot> FirstAndLastRecordSnapshot;
    public QueryBase(DbContext context)
    {
        _model = context.GetModel<TModel>();
    }

    public async Task<QueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        this.FirstAndLastRecordSnapshot = DeserializeOptions(config.Options);
        var output = await QueryAsync(config.Page, config);
        return output;
    }

    protected sealed async override Task<QueryConfigurationOutput<TResult>> ContainAsync(IQueryConfigurationInput config)
    {
        var where = Where(_model.AsNoTracking(),(byte)OptionPagination.Contain, FirstAndLastRecordSnapshot, config.Text);

        var result = await OrderByAsc(where)
          .Take(config.RowNumber)
          .Select(Columns())
          .ToListAsync();

        var first = result.FirstOrDefault();
        var last = result.LastOrDefault();

        return SetQueryConfigurationOutput(config, first, last, result);
    }

    protected sealed override async Task<QueryConfigurationOutput<TResult>> FirstAsync(IQueryConfigurationInput config)
    {
        var where = Where(_model.AsNoTracking(),(byte)OptionPagination.First, FirstAndLastRecordSnapshot, config.Text);

        var result  = await  
            OrderByAsc(where)
            .Take(config.RowNumber)
            .Select(Columns())
            .ToListAsync();
    
        var first = result.FirstOrDefault();
        var last = result.LastOrDefault();

        return SetQueryConfigurationOutput(config, first, last, result);
    }

    protected sealed override async Task<QueryConfigurationOutput<TResult>> LastAsync(IQueryConfigurationInput config)
    {
        var where = Where(_model.AsNoTracking(),(byte)OptionPagination.Last, FirstAndLastRecordSnapshot, config.Text);

        var orderByDesc =
            OrderByDesc(where).
            Take(config.RowNumber);

        var result = await OrderByAsc(orderByDesc).Select(Columns()).ToListAsync();

        var first = result.FirstOrDefault();
        var last = result.LastOrDefault();

        return SetQueryConfigurationOutput(config, first, last, result);
    }

    protected sealed override async Task<QueryConfigurationOutput<TResult>> NextAsync(IQueryConfigurationInput config)
    {
        var where = Where(_model.AsNoTracking(), (byte)OptionPagination.Next, FirstAndLastRecordSnapshot, config.Text);

        var result = await OrderByAsc(where)
        .Take(config.RowNumber)
        .Select(Columns())
        .ToListAsync();

        var first = result.FirstOrDefault();
        var last = result.LastOrDefault();

        return SetQueryConfigurationOutput(config, first, last, result);
    }

    protected sealed override async Task<QueryConfigurationOutput<TResult>> PreviousAsync(IQueryConfigurationInput config)
    {
        var where = Where(_model.AsNoTracking(), (byte)OptionPagination.Previous, FirstAndLastRecordSnapshot, config.Text);

        var orderByDesc =
            OrderByDesc(where)
            .Take(config.RowNumber);


        var result = await OrderByAsc(orderByDesc)
            .Select(Columns())
            .ToListAsync();

        var first = result.FirstOrDefault();
        var last = result.LastOrDefault();

        return SetQueryConfigurationOutput(config, first, last, result);
    }

    private FirstAndLastRecordSnapshot<TRecordSnapshot>? DeserializeOptions(string options) => JsonSerializer.Deserialize<FirstAndLastRecordSnapshot<TRecordSnapshot>>(options);
    private QueryConfigurationOutput<TResult> SetQueryConfigurationOutput(IQueryConfigurationInput config, TResult? first, TResult? last, List<TResult> data)
    {
        var output = new QueryConfigurationOutput<TResult>
        {
            Name = config.Name,
            RowNumber = config.RowNumber,
            Description = $"Consulta paginada {nameof(TResult)}",
            Data = data
        };

        if (first is null && last is null)
        {
            output.Options = config.Options;
            return output;
        }

        last ??= first;

        var fistOutput = RecordSnapshot(first);
        var lastOutput = RecordSnapshot(last);

        var firstAndLast = new FirstAndLastRecordSnapshot<TRecordSnapshot>()
        {
            First = fistOutput,
            Last = lastOutput
        };

        var firstAndLastSerialided = JsonSerializer.Serialize(firstAndLast);

        output.Options = firstAndLastSerialided;

        return output;
    }
    protected abstract TRecordSnapshot RecordSnapshot(TResult? model);
    protected abstract Expression<Func<TModel, TResult>> Columns();
    protected abstract IOrderedQueryable<TModel> OrderByAsc(IQueryable<TModel> model);
    protected abstract IOrderedQueryable<TModel> OrderByDesc(IQueryable<TModel> model);
    protected abstract IQueryable<TModel> Where(IQueryable<TModel> model, byte page, FirstAndLastRecordSnapshot<TRecordSnapshot> snapshot, string text); 
}