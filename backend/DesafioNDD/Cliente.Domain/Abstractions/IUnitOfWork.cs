
namespace Cliente.Domain.Abstractions{
    public interface IUnitOfWork
    {
        IClientesRepository ClientesRepository { get; }
        Task CommitAsync();
    }
}
