using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/voluntarios")]
    public class VoluntarioController:Controller
    {
        private IBaseRepository<VoluntarioDomain> _VoluntarioRepository;
        public VoluntarioController(IBaseRepository<VoluntarioDomain> VoluntarioRepository){
            _VoluntarioRepository=VoluntarioRepository;
        }

        [HttpGet]
        public IActionResult GetAction(){
            try{
                return Ok(_VoluntarioRepository.Listar(new string[]{"Endereco","AreaInteresse","Usuario"}));


            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]

        public IActionResult GetAction(int id){
            try{
                var voluntario= _VoluntarioRepository.BuscarPorId(id,new string[]{"Endereco","AreaInteresse","Usuario"});
                if (voluntario != null) return Ok(voluntario);
                else return NotFound();

             }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]VoluntarioDomain voluntario){
            try{
                _VoluntarioRepository.Inserir(voluntario);
                return Ok(voluntario);
                
             }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody]VoluntarioDomain voluntario){
            try{
                if(voluntario ==null || voluntario.Id !=id) return BadRequest();
                var volun=_VoluntarioRepository.BuscarPorId(id);
                if(volun==null)return NotFound();
                volun.Id=voluntario.Id;
                volun.AreaInteresseId=voluntario.AreaInteresseId;
                volun.Cpf=voluntario.Cpf;
                volun.DataNasc=voluntario.DataNasc;
                volun.Nome=voluntario.Nome;
                volun.Bio=voluntario.Bio;
                var rs=_VoluntarioRepository.Atualizar(volun);
                if(rs>0)return Ok(volun);
                else return BadRequest();
             }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try{
                var voluntarios=_VoluntarioRepository.BuscarPorId(id);
                if (voluntarios== null)return NotFound();
                var rs=_VoluntarioRepository.Deletar(voluntarios);
                 if(rs>0) return Ok();
                else return BadRequest();

             }catch(System.Exception ex){
            return BadRequest(ex.Message);
        }
        }



        
    }
}