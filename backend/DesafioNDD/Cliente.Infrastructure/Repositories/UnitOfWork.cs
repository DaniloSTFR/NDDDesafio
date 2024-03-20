using Cliente.Domain.Abstractions;
using Cliente.Infrastructure.Context;

namespace Cliente.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IClientesRepository? _clientesRepo;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IClientesRepository ClientesRepository
        {
            get
            {
                return _clientesRepo = _clientesRepo ?? 
                    new ClientesRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}