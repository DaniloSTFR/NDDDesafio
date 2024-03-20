
using System;
using Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cliente.Infrastructure.EntityConfiguration
{
    public class ClientesConfiguration : IEntityTypeConfiguration<Clientes>
    {
        public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).HasMaxLength(100).IsRequired();
            builder.Property(m => m.CPF).HasMaxLength(11).IsRequired();
            builder.Property(m => m.Sexo).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Telefone).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(100).IsRequired();
            builder.Property(m => m.DataNascimento).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Observacao).HasMaxLength(400);

            builder.HasData(
                new Clientes(Guid.NewGuid(), "João Carlos",  "22390798004", "Masculino", "91992731154", "joaocarlos@email.com", new DateTime(2005,01,10,10,15,0), "N/A" ),
                new Clientes(Guid.NewGuid(), "Maria Santos", "27201891030", "Feminino", "91982731359", "mariasantos@email.com", new DateTime(2009,05,09,11,15,0), "N/A" ),
                new Clientes(Guid.NewGuid(), "Antonio Silva","44984736046", "Masculino", "91967831359", "antoniosilva@email.com", new DateTime(1996,10,03,14,15,0), "N/A" )
            );
        }
        
    }
}