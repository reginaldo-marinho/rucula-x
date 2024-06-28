namespace Ruculax.Database.Common;

/// <summary>
///  Contracts for working with Asynchronous Logical Unit of Work
/// </summary>
public interface IUnifOfWork : IDisposable
{
    public void Begin();
    public void Commit();
    public void Rollback();
}

/// <summary>
///  Contracts for working with Logical Unit of Work
/// </summary>
public interface IUnifOfWorkAsync : IDisposable
{
    public Task BeginAsync();
    public Task CommitAsync();
    public Task RollbackAsync();
}
