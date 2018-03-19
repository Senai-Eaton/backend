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
    partial class AgirContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eaton.agir.domain.Entities.AreaAtuacaoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AreaAtuacaos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.AreaInteresseDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AreaInteresses");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaAtuacaoId");

                    b.Property<int>("AreaInteresseId");

                    b.Property<string>("Cnpj")
                        .IsRequired();

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<string>("email");

                    b.Property<string>("foto")
                        .IsRequired();

                    b.Property<string>("senha");

                    b.HasKey("Id");

                    b.HasIndex("AreaAtuacaoId");

                    b.HasIndex("AreaInteresseId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<string>("Logradouro")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EventoDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataHora");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("localId");

                    b.HasKey("Id");

                    b.HasIndex("localId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<DateTime>("DataNasc");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Profissao")
                        .IsRequired();

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<int>("areaId");

                    b.Property<string>("email");

                    b.Property<string>("foto")
                        .IsRequired();

                    b.Property<string>("senha");

                    b.HasKey("Id");

                    b.HasIndex("areaId");

                    b.ToTable("Voluntarios");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntariosEventosDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("eventoId");

                    b.Property<int>("voluntarioId");

                    b.HasKey("Id");

                    b.HasIndex("eventoId");

                    b.HasIndex("voluntarioId");

                    b.ToTable("VoluntariosEventos");
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.Empresa", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.AreaAtuacaoDomain", "AreaAtuacao")
                        .WithMany()
                        .HasForeignKey("AreaAtuacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.AreaInteresseDomain", "AreaInteresse")
                        .WithMany()
                        .HasForeignKey("AreaInteresseId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.EventoDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.Endereco", "Local")
                        .WithMany()
                        .HasForeignKey("localId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntarioDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.AreaInteresseDomain", "Area")
                        .WithMany()
                        .HasForeignKey("areaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eaton.agir.domain.Entities.VoluntariosEventosDomain", b =>
                {
                    b.HasOne("eaton.agir.domain.Entities.EventoDomain", "Evento")
                        .WithMany("VoluntariosEvento")
                        .HasForeignKey("eventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("eaton.agir.domain.Entities.VoluntarioDomain", "Voluntario")
                        .WithMany("VoluntariosEventos")
                        .HasForeignKey("voluntarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
