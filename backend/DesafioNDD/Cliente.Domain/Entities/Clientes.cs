using Cliente.Domain.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cliente.Domain.Entities
{
    [Table("Cliente")]
    public class Clientes : Entity
    {
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Sexo { get; private set; }
        public string? Telefone { get; private set; }
        public string? Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string? Observacao { get; private set; }

        public Clientes() { }

        public Clientes(string nome, string cpf, string sexo, string telefone, string email, 
                        DateTime dataNascimento,  string? observacao) 
        { 
            ValidateDomain( nome, cpf, sexo, telefone, email, dataNascimento, observacao);
        }

        [JsonConstructor]
        public Clientes(Guid id, string nome, string cpf, string sexo, string telefone, string email, 
                        DateTime dataNascimento,  string? observacao) 
        { 
            DomainValidation.When(string.IsNullOrEmpty(id.ToString()), "Id é inválido.");
            Id = id;
            ValidateDomain( nome, cpf, sexo, telefone, email, dataNascimento, observacao);
        }

        public void Update(string nome, string cpf, string sexo, string telefone, string email, 
                        DateTime dataNascimento,  string? observacao) 
        {
            ValidateDomain( nome, cpf, sexo, telefone, email, dataNascimento, observacao);
        }

        private void ValidateDomain(string nome, string cpf, string sexo, string telefone, string email, 
                            DateTime dataNascimento,  string? observacao) 
        {
            DomainValidation.When(string.IsNullOrEmpty(nome),
                "Nome é inválido. Nome é Requerido.");

            DomainValidation.When(nome.Length < 3,
                "Nome é inválido. Nome deve possui mais de 3 caracteres.");

            DomainValidation.When(string.IsNullOrEmpty(cpf),
                "CPF é inválido. LastName is required.");

            DomainValidation.When(cpf.Length != 11,
                "CPF é inválido. O CPF deve possuir mais de 11 caracteres.");

            DomainValidation.When(string.IsNullOrEmpty(sexo),
                "Sexo é inválido. Nome é Requerido.");

            DomainValidation.When(telefone.Length < 10,
                "Telefone é inválido. O Telefone deve possuir mais de 10 caracteres.");

            DomainValidation.When(string.IsNullOrEmpty(email),
                "Email é inválido. Email é Requerido.");

            DomainValidation.When(email?.Length > 250,
                "Email é inválido. Muito longo, no máximo 250 caracteres");

            DomainValidation.When(email?.Length < 6,
                "Email é inválido. Muito curto, no mínimo 7 caracteres");

            DomainValidation.When(string.IsNullOrEmpty(dataNascimento.ToString()),
                "Data Nascimento é inválido. Data Nascimento é Requerido.");

            Nome = nome;
            CPF = cpf;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            Observacao = observacao;
        }

        
    }
}