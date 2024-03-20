
using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Infrastructure.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        protected readonly AppDbContext db;

        public ClientesRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<Clientes>> GetClientes()
        {
            var clientelist = await db.Clientes.ToListAsync();
            return clientelist ?? Enumerable.Empty<Clientes>();
        }

        public async Task<Clientes> GetClienteById(string clienteId)
        {
            var cliente = await db.Clientes.FindAsync(new Guid(clienteId));

            if (cliente is null)
                throw new InvalidOperationException("Cliente não encontrado!");

            return cliente;
        }

        public async Task<Clientes> AddCliente(Clientes cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            await db.Clientes.AddAsync(cliente);
            return cliente;
        }

        public void UpdateCliente(Clientes cliente)
        {
            if (cliente is null)
                throw new ArgumentNullException(nameof(cliente));

            db.Clientes.Update(cliente);
        }

        public async Task<Clientes> DeleteMember(string clienteId)
        {
            var cliente = await GetClienteById(clienteId);

            if (cliente is null)
                throw new InvalidOperationException("Cliente não encontrado");

            db.Clientes.Remove(cliente);
            return cliente;
        }       

        
    }
}