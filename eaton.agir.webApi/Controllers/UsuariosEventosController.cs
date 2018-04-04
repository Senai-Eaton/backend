using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/usuarioseventos")]
    public class UsuariosEventosController : Controller
    {
        public UsuarioEventoRepository _usuariosEventosRepository;
        public UsuariosEventosController(UsuarioEventoRepository usuariosEventosRepository)
        {
            _usuariosEventosRepository = usuariosEventosRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuariosEventosRepository.Listar(new string[]{"Voluntario","Empresa"}));
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
        [HttpPost]
        public IActionResult Cadastrar([FromBody]UsuarioEventoDomain model)
        {
            try
            {
                if(_usuariosEventosRepository.UsuarioEventoExiste(model.UsuarioId, model.EventoId));
                    return BadRequest("Usuário já cadastrado para o evento");

                _usuariosEventosRepository.Inserir(model);
                return Ok(model);
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