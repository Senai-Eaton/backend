using System;
using System.Data.Entity;
using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.repository.Context;

namespace eaton.agir.repository.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioDomain>, IUsuarioRepository
    {
        AgirContext _context;
        public UsuarioRepository(AgirContext context)
        : base(context)
        {
            _context = context;
        }

        

        public UsuarioDomain Autenticar(string email, string senha, string[] includes = null)
        {
            try
            {

                string[] includes_ = new string[]{"Voluntario","Empresa"};

                var query = _context.Usuarios.Include("Voluntario").Include("Empresa").Where(x => x.Email.ToLower() == email.ToLower() && x.Senha == senha);

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioDomain VerificaUsuarioExiste(string email)
        {
            try
            {
                string[] includes = new string[]{"Voluntario","Voluntario.VoluntariosEventos","Voluntario.VoluntariosEventos.Evento","Empresa","Empresa.Evento"};

                var query = _context.Usuarios.AsQueryable();

                foreach (var item in includes)
                {
                    query.Include(item);
                }
                return query.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}