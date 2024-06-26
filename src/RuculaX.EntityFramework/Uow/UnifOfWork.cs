using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common;

namespace RuculaX.EntityFramework;

sealed public class UnitOfWorkAsync : IUnifOfWorkAsync 
{
    public UnitOfWorkAsync(DbContext context)
    {
        _context = context;
    }
    private DbContext _context;


    public async Task BeginAsync() =>  await _context.Database.BeginTransactionAsync();
    public async Task CommitAsync()  =>  await _context.Database.CommitTransactionAsync();
    public async Task RollbackAsync() => await  _context.Database.RollbackTransactionAsync();
    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    private bool _disposed;

    public void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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
