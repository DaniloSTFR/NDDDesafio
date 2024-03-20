using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Application.ClientesApp.Abstractions;
using MediatR;

namespace Cliente.Application.ClientesApp.Queries
{
    public class GetClienteByIdQuery : IRequest<Clientes>
    {
        public string Id { get; set; }

        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Clientes>
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetClienteByIdQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clientes> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
            {
                var clientes = await _unitOfWork.ClientesRepository.GetClienteById(request.Id);
                return clientes;
            }
        }

    }
}