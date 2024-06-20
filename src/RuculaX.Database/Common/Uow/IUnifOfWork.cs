namespace Ruculax.Database.Common;

public interface IUnifOfWork : IDisposable
{
    public void Begin();
    public void Commit();
    public void Rollback();
}

public interface IUnifOfWorkAsync : IDisposable
{
    public Task BeginAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}
