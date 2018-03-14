using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers
{
   [Route("api/[controller]")]
    public class AreaInteresseController:Controller
    {
        
        
        private IBaseRepository<AreaInteresseDomain> _areaInteresseRepository;

        public AreaInteresseController (IBaseRepository<AreaInteresseDomain>areaInteresseRepository) {
            _areaInteresseRepository=areaInteresseRepository;
        }
        [HttpGet]
        public IActionResult GetAction(){
            try{
                return Ok(_areaInteresseRepository.Listar());

            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id){
            var area =_areaInteresseRepository.BuscarPorId(id);
            if(area != null)
            return Ok(area);
            else 
            return NotFound();
        }
        [HttpPost]
        public IActionResult Cadastrar([FromBody]AreaInteresseDomain area){
            try{
                _areaInteresseRepository.Inserir(area);
                return Ok(area);
            }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,[FromBody]AreaInteresseDomain area){
            if (area==null ||area.Id !=id){
                 return BadRequest();
             }
            var area1 =_areaInteresseRepository.BuscarPorId(id);
            if(area1== null){
                return NotFound();

            }
            area1.Id= area.Id;
            area1.Nome=area.Nome;
            var rs= _areaInteresseRepository.Atualizar(area1);
            if (rs>0) return Ok(area1);
            else return BadRequest();






        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id){
            var areas=_areaInteresseRepository.BuscarPorId(id);
            if(areas==null){
                return NotFound ();
            }

            var rs = _areaInteresseRepository.Deletar(areas);
            if (rs>0) return Ok();
            else 
           return BadRequest();
            
            
        }
    }
}