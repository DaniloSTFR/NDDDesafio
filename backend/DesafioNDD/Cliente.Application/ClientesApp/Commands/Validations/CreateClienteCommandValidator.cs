using FluentValidation;

namespace Cliente.Application.ClientesApp.Commands.Validations
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Por favor insira um Nome!")
            .Length(4, 100).WithMessage("O nome deve conter entre 4 e 10 caracteres!");

            RuleFor(c => c.CPF)
            .NotEmpty().WithMessage("Por favor insira o CPF!")
            .Length(11).WithMessage("O CPF deve conter 11 Caracteres!");

            RuleFor(c => c.Sexo)
                .NotEmpty()
                .MinimumLength(4)
                .WithMessage("Informe um valor para Sexo valido!");

            RuleFor(c => c.Telefone)
            .NotEmpty().WithMessage("Por favor insira um Telefone!")
            .Length(8, 20).WithMessage("O Telefone deve conter entre 8 e 20 caracteres!");

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Informe um Email valido!")
            .EmailAddress().WithMessage("Informe um Email valido!");

            RuleFor(c => c.DataNascimento)
            .NotEmpty().WithMessage("Informe uma Data de Nascimento valida");
            
        }
    }
}