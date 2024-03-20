using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Application.ClientesApp.Abstractions;
using MediatR;

namespace Cliente.Application.ClientesApp.Commands
{
    public class DeleteClienteCommand : ClientesCommandBase
    {
        public string Id { get; set; }
        public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Clientes>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteClienteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clientes> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
            {
                var deletedCliente = await _unitOfWork.ClientesRepository.DeleteCliente(request.Id);

                if (deletedCliente is null)
                    throw new InvalidOperationException("Cliente não Encontrado");

                await _unitOfWork.CommitAsync();
                return deletedCliente;
            }
        }
        
    }
}