
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
        public DbSet<AreaInteresseDomain> AreaInteresses {get;set;}
        
        public DbSet<Endereco> Enderecos {get;set;}
        public DbSet<Empresa> Empresas {get;set;}
        public DbSet<EventoDomain> Eventos {get;set;}
        public DbSet<VoluntarioDomain> Voluntarios {get;set;}
        protected  override void OnModelCreating (ModelBuilder modelBuilder){
        modelBuilder.Entity<AreaAtuacaoDomain>().ToTable("AreaAtuacaos");
        modelBuilder.Entity<AreaInteresseDomain>().ToTable("AreaInteresses");
        modelBuilder.Entity<Endereco>().ToTable("enderecos");
        modelBuilder.Entity<Empresa>().ToTable("Empresas");
        modelBuilder.Entity<EventoDomain>().ToTable("Eventos");
        modelBuilder.Entity<VoluntarioDomain>().ToTable("Voluntarios");


        base.OnModelCreating(modelBuilder);
        }

        
    }
}