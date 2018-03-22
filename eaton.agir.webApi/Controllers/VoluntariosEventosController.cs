using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/[Controller]")]
    public class VoluntariosEventosController : Controller
    {
        public IBaseRepository<VoluntariosEventosDomain> _voluntarioEventoRepository;
        public VoluntariosEventosController(IBaseRepository<VoluntariosEventosDomain> voluntariosEventosRepository)
        {
            _voluntarioEventoRepository = voluntariosEventosRepository;
        }
        [HttpGet]
        public IActionResult GetAction()
        {
            try
            {
                return Ok(_voluntarioEventoRepository.Listar());

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            try
            {
                var volu = _voluntarioEventoRepository.BuscarPorId(id);
                if (volu != null) return Ok(volu);
                else return NotFound();


            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]VoluntariosEventosDomain volunt)
        {
            try
            {
                _voluntarioEventoRepository.Inserir(volunt);
                return Ok(volunt);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]VoluntariosEventosDomain voluntarios)
        {
            try
            {
                if (voluntarios == null || voluntarios.Id != id) return BadRequest();
                var volun = _voluntarioEventoRepository.BuscarPorId(id);
                if (volun == null) return NotFound();
                volun.Id = voluntarios.Id;
                volun.eventoId = voluntarios.eventoId;
                volun.voluntarioId = voluntarios.voluntarioId;
                volun.Data = volun.Data;

                var rs = _voluntarioEventoRepository.Atualizar(volun);
                if (rs > 0) return Ok(volun);
                else return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var voluntarios = _voluntarioEventoRepository.BuscarPorId(id);
                if (voluntarios == null) return NotFound();
                var rs = _voluntarioEventoRepository.Deletar(voluntarios);
                if (rs > 0) return Ok();
                else return BadRequest();

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}