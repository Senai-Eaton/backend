using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.repository.Repositories;
using eaton.agir.webApi.ViewModels.UsuarioEvento;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/usuarioseventos")]
    public class UsuariosEventosController : Controller
    {
        IUsuarioEventoRepository _usuariosEventosRepository;
        public UsuariosEventosController(IUsuarioEventoRepository usuariosEventosRepository)
        {
            _usuariosEventosRepository = usuariosEventosRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuariosEventosRepository.Listar(new string[]{"Usuario.Voluntario","Usuario.Empresa","Evento"}));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        


        [HttpGet("buscareventoporidusuario/{id}")]
        [Route("buscareventoporidusuario/{id}")]
        public IActionResult BuscarEventoPorIdUsuario(int id)
        {
            try
            {
                var eventos = _usuariosEventosRepository.Listar(new string[]{"Usuario.Voluntario","Usuario.Empresa","Evento"}).Where(x => x.UsuarioId == id);
                if (eventos != null){
                    var retornoEventos = eventos.Select(x => new {
                        id = x.Id,
                        idempresa = x.Evento.EmpresaId,
                        nome = x.Evento.Nome,
                        foto = x.Evento.Foto,
                        datahora = x.Evento.DataHora
                    }).ToList();
                    return Ok(retornoEventos);
                }
                else{
                    return NotFound("Não foram encontrados eventos para o usuário");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um usuário no evento
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /cadastrar
        ///     {
        ///         "idUsuario" : 1,
        ///         "idEvento" : 2
        ///     }
        /// 
        /// </remarks>
        /// <param name="model">Tipo de dados a serem passados</param>
        /// <returns></returns>
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody]CadastrarUsuarioEventoViewModel model)
        {
            try
            {
                if(_usuariosEventosRepository.UsuarioEventoExiste(model.idUsuario, model.idEvento))
                    return BadRequest("Usuário já cadastrado para este evento");

                UsuarioEventoDomain usuarioEvento = new UsuarioEventoDomain();
                usuarioEvento.UsuarioId = model.idUsuario;
                usuarioEvento.EventoId = model.idEvento;

                _usuariosEventosRepository.Inserir(usuarioEvento);
                return Ok(usuarioEvento);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]UsuarioEventoDomain voluntarios)
        {
            try
            {
                if (voluntarios == null || voluntarios.Id != id) return BadRequest();
                var volun = _usuariosEventosRepository.BuscarPorId(id);
                if (volun == null) return NotFound();
                volun.Id = voluntarios.Id;
                volun.EventoId = voluntarios.EventoId;
                //volun.UsuarioId = voluntarios.VoluntarioId;

                var rs = _usuariosEventosRepository.Atualizar(volun);
                if (rs > 0) return Ok(volun);
                else return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("excluir/{id}")]
        [Route("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var voluntarios = _usuariosEventosRepository.BuscarPorId(id);

                if (voluntarios == null) 
                    return NotFound();
                
                var rs = _usuariosEventosRepository.Deletar(voluntarios);
                if (rs > 0) 
                    return Ok();
                else 
                    return BadRequest();

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}