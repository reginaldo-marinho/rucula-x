using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common;

namespace RuculaX.EntityFramework;

sealed public class UnitOfWorkAsync: IUnifOfWorkAsync 
{
    public UnitOfWorkAsync(DbContext context)
    {
        Context = context;
    }

    private DbContext Context;

    public async Task BeginAsync() =>  await Context.Database.BeginTransactionAsync();
    public async Task CommitAsync()  =>  await Context.Database.CommitTransactionAsync();
    public async Task RollbackAsync() => await  Context.Database.RollbackTransactionAsync();

    private bool _disposed;

    public void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }
}
