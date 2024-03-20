
using Cliente.Domain.Entities;

namespace Cliente.Domain.Abstractions
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetClientes();
        Task<Clientes> GetClienteById(string clienteId);
        Task<Clientes> AddCliente(Clientes cliente);
        void UpdateCliente(Clientes cliente);
        Task<Clientes> DeleteCliente(string clienteId);
        
    }
}