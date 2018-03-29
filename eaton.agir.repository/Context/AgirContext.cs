
using System.Linq;
using eaton.agir.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eaton.agir.repository.Context
{
    public class AgirContext: DbContext

    {
        public AgirContext(DbContextOptions<AgirContext> options): base(options)
        {
            
        }
        public DbSet<AreaAtuacaoDomain> AreaAtuacaos {get;set;}
        public DbSet<EnderecoDomain> Enderecos {get;set;}
        public DbSet<EmpresaDomain> Empresas {get;set;}
        public DbSet<EventoDomain> Eventos {get;set;}
        public DbSet<VoluntarioDomain> Voluntarios {get;set;}
        public DbSet<VoluntarioEventoDomain> VoluntariosEventos{get;set;}
        public DbSet<UsuarioDomain> Usuarios{get;set;}
        
        protected  override void OnModelCreating (ModelBuilder modelBuilder){
           
           foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            modelBuilder.Entity<AreaAtuacaoDomain>().ToTable("AreaAtuacoes");
            modelBuilder.Entity<EnderecoDomain>().ToTable("Enderecos");
            modelBuilder.Entity<EmpresaDomain>().ToTable("Empresas");
            modelBuilder.Entity<EventoDomain>().ToTable("Eventos");
            modelBuilder.Entity<VoluntarioDomain>().ToTable("Voluntarios");
            modelBuilder.Entity<VoluntarioEventoDomain>().ToTable("VoluntariosEventos");
            modelBuilder.Entity<UsuarioDomain>().ToTable("Usuarios");

            base.OnModelCreating(modelBuilder);
        }
    }
}