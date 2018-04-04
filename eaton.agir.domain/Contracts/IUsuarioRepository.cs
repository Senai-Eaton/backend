using eaton.agir.domain.Entities;

namespace eaton.agir.domain.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioDomain>
    {
        UsuarioDomain VerificaUsuarioExiste(string email);
        UsuarioDomain Autenticar(string email, string senha, string[] includes = null);
    }
}