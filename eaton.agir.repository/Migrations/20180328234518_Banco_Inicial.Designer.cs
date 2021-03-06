﻿// <auto-generated />
using eaton.agir.repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace eaton.agir.repository.Migrations
{
    [DbContext(typeof(AgirContext))]
    [Migration("20180328234518_Banco_Inicial")]
    partial class Banco_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eaton.agir.domain.Entities.AreaAtuacaoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AreaAtuacoes");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EmpresaDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaAtuacaoId");

                    b.Property<string>("Cnpj")
                        .IsRequired();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(650);

                    b.Property<int>("EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("AreaAtuacaoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EnderecoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("Cep");

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Logradouro")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EventoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("EmpresaId");

                    b.Property<int>("LocalId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("LocalId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.UsuarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Email");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Senha");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaInteresseId");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(650);

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("AreaInteresseId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioEventoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<int>("EventoId");

                    b.Property<int>("VoluntarioId");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("VoluntarioId");

                    b.ToTable("VoluntariosEventos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EmpresaDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.AreaAtuacaoDomain", "AreaAtuacao")
                        .WithMany()
                        .HasForeignKey("AreaAtuacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.EnderecoDomain", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.UsuarioDomain", "Usuario")
                        .WithOne("Empresa")
                        .HasForeignKey("eaton.agir.domain.Entities.EmpresaDomain", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EventoDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.EmpresaDomain", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.EnderecoDomain", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.AreaAtuacaoDomain", "AreaInteresse")
                        .WithMany()
                        .HasForeignKey("AreaInteresseId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.UsuarioDomain", "Usuario")
                        .WithOne("Voluntario")
                        .HasForeignKey("eaton.agir.domain.Entities.VoluntarioDomain", "UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioEventoDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.EventoDomain", "Evento")
                        .WithMany("VoluntariosEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.VoluntarioDomain", "Voluntario")
                        .WithMany("VoluntariosEventos")
                        .HasForeignKey("VoluntarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
