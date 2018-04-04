using eaton.agir.domain.Entities;

namespace eaton.agir.domain.Contracts
{
    public interface IUsuarioEventoRepository: IBaseRepository<UsuarioEventoDomain>
    {
         bool UsuarioEventoExiste(int idUsuario, int idEvento);
    }
}