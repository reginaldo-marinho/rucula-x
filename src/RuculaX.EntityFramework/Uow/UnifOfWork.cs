using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common;

namespace RuculaX.EntityFramework;

sealed public class UnitOfWorkAsync<T> : IUnifOfWorkAsync<T> where T : DbContext 
{
    public UnitOfWorkAsync(T context)
    {
        Context = context;
    }
    
    protected T Context;

    public async Task BeginAsync() =>  await Context.Database.BeginTransactionAsync();
    public async Task CommitAsync()  => await Context.Database.BeginTransactionAsync();
    public async Task RollbackAsync() => await  Context.Database.BeginTransactionAsync();

    public void Dispose()
    {        
        GC.SuppressFinalize(this);
    }
}
