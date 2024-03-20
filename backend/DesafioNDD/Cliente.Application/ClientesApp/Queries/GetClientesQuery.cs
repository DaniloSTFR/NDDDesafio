using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Application.ClientesApp.Abstractions;
using MediatR;

namespace Cliente.Application.ClientesApp.Queries
{
    public class GetClientesQuery : IRequest<IEnumerable<Clientes>>
    {
        public class GetClientesQueryHandler : IRequestHandler<GetClientesQuery, IEnumerable<Clientes>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetClientesQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Clientes>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
            {
                var clientes = await _unitOfWork.ClientesRepository.GetClientes();
                return clientes;
            }
        }
        
    }
}