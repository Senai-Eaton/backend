using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/enderecos")]
    public class EnderecoController: Controller
    {
        private IBaseRepository<EnderecoDomain>_enderecoRepository;

        public EnderecoController(IBaseRepository<EnderecoDomain>enderecoRepository){
            _enderecoRepository=enderecoRepository;
        }
        [HttpGet]
        public IActionResult GetAction(){
            try{
                //new string[]{"VoluntariosEventos.Voluntario"})
                return Ok(_enderecoRepository.Listar());
            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetAction (int id){
            try{
                var ende=_enderecoRepository.BuscarPorId(id);
                if(ende!=null){
                    return Ok(ende);
                }
                else return NotFound();

            }catch(System.Exception ex){
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]EnderecoDomain ende){
                try{
                    _enderecoRepository.Inserir(ende);
                    return Ok(ende);
                }catch(System.Exception ex){
                return BadRequest(ex.Message);

                }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int Id,[FromBody]EnderecoDomain ende){
            try{
                
                if(ende==null || ende.Id!=Id){
                    return BadRequest();
                }
                
                var ende1 =_enderecoRepository.BuscarPorId(Id);
                
                if (ende1== null){
                    return NotFound();
                }

                ende1.Id=ende.Id;
                ende1.Bairro=ende.Bairro;
                ende1.Cidade=ende.Cidade;
                ende1.Estado=ende.Estado;
                ende1.Logradouro=ende.Logradouro;
                ende1.Numero=ende.Numero;
                var rs= _enderecoRepository.Atualizar(ende1);
                
                if(rs > 0) 
                    return Ok(ende1);
                else 
                    return BadRequest();
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var endes=_enderecoRepository.BuscarPorId(id);
            if (endes==null){
                return NotFound();
            }

            var rs=_enderecoRepository.Deletar(endes);
            if (rs>0) return Ok();
            else return BadRequest();
        }
    }
}