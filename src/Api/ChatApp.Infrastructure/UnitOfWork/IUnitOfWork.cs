namespace ChatApp.Infrastructure.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}
