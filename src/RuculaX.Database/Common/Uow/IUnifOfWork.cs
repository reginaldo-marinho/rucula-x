namespace Ruculax.Database.Common;

public interface IUnifOfWork<T> : IDisposable
{
    public void Begin();
    public void Commit();
    public void Rollback();
}

public interface IUnifOfWorkAsync<T> : IDisposable
{
    public Task BeginAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}
