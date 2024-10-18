namespace Kian.Contract.Repositories
{
    public interface IUnitOFWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
