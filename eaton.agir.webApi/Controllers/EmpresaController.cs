using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eaton.agir.webApi.Controllers {
    [Route ("api/empresas")]
    public class EmpresaController : Controller {
        private IBaseRepository<EmpresaDomain> _empresaRepository;

        public EmpresaController (IBaseRepository<EmpresaDomain> EmpresaRepository) {
            _empresaRepository = EmpresaRepository;
        }

        [HttpGet]
        public IActionResult GetAction () {
            try {
                return Ok (_empresaRepository.Listar (new string[] { "Endereco", "AreaAtuacao", "Usuario" }));

            } catch (System.Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpGet ("{id}")]
        public IActionResult GetAction (int id) {
            try {
                var empre = _empresaRepository.BuscarPorId (id,new string[]{ "Endereco", "AreaAtuacao", "Usuario" });
                if (empre != null) return Ok (empre);
                else return NotFound ();

            } catch (System.Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar ([FromBody] EmpresaDomain empre) {
            try {
                _empresaRepository.Inserir (empre);
                return Ok (empre);
            } catch (System.Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpPut ("{id}")]
        public IActionResult Atualizar (int id, [FromBody] EmpresaDomain empre) {
            try {
                if (empre == null || empre.Id != id) {
                    return BadRequest ();
                }
                var empre1 = _empresaRepository.BuscarPorId (id);
                if (empre1 == null) {
                    return NotFound ();
                }
                empre1.Id = empre.Id;
                empre1.AreaAtuacaoId = empre.AreaAtuacaoId;
                empre1.Cnpj = empre.Cnpj;
                empre1.RazaoSocial = empre.RazaoSocial;

                var rs = _empresaRepository.Atualizar (empre1);
                if (rs > 0)
                    return Ok (empre1);
                else
                    return BadRequest ();

            } catch (System.Exception ex) {
                return BadRequest (ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id) {
            try {
                var empres = _empresaRepository.BuscarPorId (id);
                if (empres == null) {
                    return NotFound ();
                }
                var rs = _empresaRepository.Deletar (empres);
                if (rs > 0) return Ok ();
                else return BadRequest ();
            } catch (System.Exception ex) {
                return BadRequest (ex.Message);
            }
        }

    }
}