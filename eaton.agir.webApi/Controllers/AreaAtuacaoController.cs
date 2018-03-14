using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
    [Route("api/[controller]")]
    public class AreaAtuacaoController : Controller{
        private IBaseRepository<AreaAtuacaoDomain> _areaAtuacaoRepository;

        public AreaAtuacaoController (IBaseRepository<AreaAtuacaoDomain>areaAtuacaoRepository) {
            _areaAtuacaoRepository=areaAtuacaoRepository;
        }
        [HttpGet]
        public IActionResult GetAction(){
            try{
                return Ok(_areaAtuacaoRepository.Listar());

            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            var area =_areaAtuacaoRepository.BuscarPorId(id);
            if(area != null)
            return Ok(area);
            else 
            return NotFound();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]AreaAtuacaoDomain area){
            try{
                _areaAtuacaoRepository.Inserir(area);
                return Ok(area);
            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody]AreaAtuacaoDomain area){
            if (area==null ||area.Id !=id){
                 return BadRequest();
             }
            var area1 =_areaAtuacaoRepository.BuscarPorId(id);
            if(area1== null){
                return NotFound();

            }
            area1.Id= area.Id;
            area1.Nome=area.Nome;
            var rs= _areaAtuacaoRepository.Atualizar(area1);
            if (rs>0) return Ok();
            else return BadRequest();






        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id){
            var areas=_areaAtuacaoRepository.BuscarPorId(id);
            if(areas==null){
                return NotFound ();
            }

            var rs = _areaAtuacaoRepository.Deletar(areas);
            if (rs>0) return Ok();
            else 
           return BadRequest();
            
            
        }
        
    }
}