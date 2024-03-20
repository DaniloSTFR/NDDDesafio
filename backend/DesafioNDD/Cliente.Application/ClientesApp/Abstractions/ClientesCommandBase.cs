using Cliente.Domain.Entities;
using MediatR;

namespace Cliente.Application.ClientesApp.Abstractions
{
    public abstract class ClientesCommandBase: IRequest<Clientes>
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Sexo { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Observacao { get; set; }
    }
    
}