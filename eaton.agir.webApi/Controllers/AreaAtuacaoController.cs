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
        
    }
}