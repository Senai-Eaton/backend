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

        

        public UsuarioDomain Autenticar(string email, string senha)
        {
            try
            {
                UsuarioDomain usuario = _context.Usuarios.Include("Voluntario")
                                        .Include("Empresa")
                                        .Include("Empresa.Eventos")
                                        .FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Senha == senha);

                return usuario;
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
                return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}