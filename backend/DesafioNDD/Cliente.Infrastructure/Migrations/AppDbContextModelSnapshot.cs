﻿// <auto-generated />
using System;
using Cliente.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cliente.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cliente.Domain.Entities.Clientes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            Id = new Guid("faf12856-af40-4033-bf4b-9695b9456168"),
                            CPF = "22390798004",
                            DataNascimento = new DateTime(2005, 1, 10, 10, 15, 0, 0, DateTimeKind.Unspecified),
                            Email = "joaocarlos@email.com",
                            Nome = "João Carlos",
                            Observacao = "N/A",
                            Sexo = "Masculino",
                            Telefone = "91992731154"
                        },
                        new
                        {
                            Id = new Guid("8ca2ef90-5078-42f0-aee7-13610bdec03c"),
                            CPF = "27201891030",
                            DataNascimento = new DateTime(2009, 5, 9, 11, 15, 0, 0, DateTimeKind.Unspecified),
                            Email = "mariasantos@email.com",
                            Nome = "Maria Santos",
                            Observacao = "N/A",
                            Sexo = "Feminino",
                            Telefone = "91982731359"
                        },
                        new
                        {
                            Id = new Guid("c406794e-77f1-400c-9c0a-827cbe1beafa"),
                            CPF = "44984736046",
                            DataNascimento = new DateTime(1996, 10, 3, 14, 15, 0, 0, DateTimeKind.Unspecified),
                            Email = "antoniosilva@email.com",
                            Nome = "Antonio Silva",
                            Observacao = "N/A",
                            Sexo = "Masculino",
                            Telefone = "91967831359"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
