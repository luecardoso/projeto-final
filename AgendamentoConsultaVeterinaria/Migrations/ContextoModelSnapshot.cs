﻿// <auto-generated />
using System;
using AgendamentoConsultaVeterinaria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendamentoConsultaVeterinaria.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.AnimalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Castrado")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Raca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAnimal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.ConsultaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("HoraConsulta")
                        .HasColumnType("time");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusConsulta")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.EnderecoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.MedicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Crmv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeId")
                        .IsUnique();

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.UnidadeModel", b =>
                {
                    b.Property<int>("UnidadeModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnidadeModelId"), 1L, 1);

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("HorarioFuncionamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnidadeModelId");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.AnimalModel", b =>
                {
                    b.HasOne("AgendamentoConsultaVeterinaria.Models.ClienteModel", "Cliente")
                        .WithMany("Animais")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.ClienteModel", b =>
                {
                    b.HasOne("AgendamentoConsultaVeterinaria.Models.EnderecoModel", "Endereco")
                        .WithOne()
                        .HasForeignKey("AgendamentoConsultaVeterinaria.Models.ClienteModel", "EnderecoId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.ConsultaModel", b =>
                {
                    b.HasOne("AgendamentoConsultaVeterinaria.Models.AnimalModel", "Animal")
                        .WithMany("Consultas")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendamentoConsultaVeterinaria.Models.MedicoModel", "Medico")
                        .WithMany("Consultas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendamentoConsultaVeterinaria.Models.UnidadeModel", "Unidade")
                        .WithMany("Consultas")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Medico");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.MedicoModel", b =>
                {
                    b.HasOne("AgendamentoConsultaVeterinaria.Models.UnidadeModel", "Unidade")
                        .WithOne()
                        .HasForeignKey("AgendamentoConsultaVeterinaria.Models.MedicoModel", "UnidadeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.UnidadeModel", b =>
                {
                    b.HasOne("AgendamentoConsultaVeterinaria.Models.EnderecoModel", "Endereco")
                        .WithOne()
                        .HasForeignKey("AgendamentoConsultaVeterinaria.Models.UnidadeModel", "EnderecoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.AnimalModel", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.ClienteModel", b =>
                {
                    b.Navigation("Animais");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.MedicoModel", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("AgendamentoConsultaVeterinaria.Models.UnidadeModel", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
