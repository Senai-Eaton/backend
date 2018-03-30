using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/eventos")]
    public class EventoController: Controller
    {
        private IBaseRepository<EventoDomain> _EventoRepository;

        public EventoController(IBaseRepository<EventoDomain>eventoRepository){
            _EventoRepository=eventoRepository;
        }
        [HttpGet]
        public IActionResult GetAction(){
            try{
                return Ok(_EventoRepository.Listar(new string[]{"Local","VoluntariosEventos.Voluntario","Empresa"}));

             }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            try{
                var evento = _EventoRepository.BuscarPorId(id,new string[]{"Local","VoluntariosEventos.Voluntario","Empresa"});
                if(evento != null) return Ok(evento);
                else return NotFound();

            }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]EventoDomain evento){
            try{
                _EventoRepository.Inserir(evento);
                return Ok(evento);

            }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody]EventoDomain evento){
            try{
                if(evento==null ||evento.Id !=id) return BadRequest();
                var evento1=_EventoRepository.BuscarPorId(id);
                if (evento1==null) return NotFound();
                evento1.Id=evento.Id;
                evento1.Descricao=evento.Descricao;
                evento1.LocalId=evento.LocalId;
                evento1.Nome=evento.Nome;
                evento1.DataHora=evento.DataHora;
                var rs=_EventoRepository.Atualizar(evento1);
                if (rs>0 )return Ok(evento1);
                else return BadRequest();
            }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try{
                var eventos=_EventoRepository.BuscarPorId(id);
                if(eventos==null)return NotFound();
                var rs=_EventoRepository.Deletar(eventos);
                 if(rs>0) return Ok();
                else return BadRequest();



            }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }






        
        
    }
}