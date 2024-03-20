using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Application.ClientesApp.Abstractions;
using MediatR;


namespace Cliente.Application.ClientesApp.Commands
{
    public class UpdateClienteCommand : ClientesCommandBase
    {
        public string Id { get; set; }
        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Clientes>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateClienteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clientes> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
            {
                var existingCliente = await _unitOfWork.ClientesRepository.GetClienteById(request.Id);

                if (existingCliente is null){
                    throw new InvalidOperationException("Cliente não encontrado");
                    }

                existingCliente.Update( request.Nome, 
                                        request.CPF, 
                                        request.Sexo, 
                                        request.Telefone, 
                                        request.Email, 
                                        request.DataNascimento,
                                        request.Observacao) ;

                _unitOfWork.ClientesRepository.UpdateCliente(existingCliente);
                await _unitOfWork.CommitAsync();
                return existingCliente;
            }

        }
        
    }
}