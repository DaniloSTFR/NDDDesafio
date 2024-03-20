using Cliente.Domain.Abstractions;
using Cliente.Domain.Entities;
using Cliente.Application.ClientesApp.Abstractions;
using FluentValidation;
using MediatR;

namespace Cliente.Application.ClientesApp.Commands
{
    public class CreateClienteCommand : ClientesCommandBase
    {

        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Clientes>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateClienteCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Clientes> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
            {
                var toCreateCliente = new Clientes( request.Nome, request.CPF, request.Sexo, request.Telefone, request.Email, request.DataNascimento, request.Observacao);

                var createdCliente = await _unitOfWork.ClientesRepository.AddCliente(toCreateCliente);
                await _unitOfWork.CommitAsync();

                return createdCliente;
            }
        }
    }
}