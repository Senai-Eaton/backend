using System;
using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.repository.Context;

namespace eaton.agir.repository.Repositories
{
    public class UsuarioEventoRepository : BaseRepository<UsuarioEventoDomain>, IUsuarioEventoRepository
    {
        AgirContext _context;
        public UsuarioEventoRepository(AgirContext context)
        : base(context)
        {
            _context = context;
        }

        public bool UsuarioEventoExiste(int idUsuario, int idEvento)
        {
            try
            {
                return _context.UsuariosEventos.Any(x => x.UsuarioId == idUsuario && x.EventoId == idEvento);
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}