namespace ChatApp.Infrastructure.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
