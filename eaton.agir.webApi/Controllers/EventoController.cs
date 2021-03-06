using System.Collections.Generic;
using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        [Route("listar")]
        public IActionResult Listar(){
            try{
                var eventos = _EventoRepository.Listar(new string[]{"Local","UsuariosEventos.Usuario","Empresa"});

                var retornoEvento = eventos.Select(evento => new {
                        nome = evento.Nome,
                        descricao = evento.Descricao,
                        foto = evento.Foto,
                        datahora = evento.DataHora,
                        local = new {
                            logradouro = evento.Local.Logradouro,
                            numero = evento.Local.Numero,
                            bairro = evento.Local.Bairro,
                            cidade = evento.Local.Cidade,
                            estado = evento.Local.Estado,
                            cep = evento.Local.Cep
                        }
                    }).ToList();

                return Ok(retornoEvento);

             }catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarporid/{id}")]
        [Route("buscarporid/{id}")]
        public IActionResult BurcarPorId(int id){
            try{
                var evento = _EventoRepository.BuscarPorId(id,new string[]{"Local","UsuariosEventos","Empresa"});
                if(evento != null)
                {
                    var retornoEvento = new {
                        nome = evento.Nome,
                        descricao = evento.Descricao,
                        foto = evento.Foto,
                        datahora = evento.DataHora,
                        local = new {
                            logradouro = evento.Local.Logradouro,
                            numero = evento.Local.Numero,
                            bairro = evento.Local.Bairro,
                            cidade = evento.Local.Cidade,
                            estado = evento.Local.Estado,
                            cep = evento.Local.Cep
                        }
                    };
                    return Ok(retornoEvento);
                }
                else return NotFound();

            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("participantes/{id}")]
        [Route("participantes/{id}")]
        public IActionResult Participantes(int id){
            try{
                var evento = _EventoRepository.BuscarPorId(id,new string[]{"Local","UsuariosEventos", "UsuariosEventos.Usuario", "UsuariosEventos.Usuario.Empresa","UsuariosEventos.Usuario.Voluntario","Empresa"});

                if(evento != null)
                {
                    var retornoEvento = new {
                        quantidade = evento.UsuariosEventos.Count,
                        usuarios = evento.UsuariosEventos.Select(x => new {
                            id = x.Id,
                            nome = (x.Usuario.TipoUsuario == "Empresa" ? x.Usuario.Empresa.Nome : x.Usuario.Voluntario.Nome),
                            email = x.Usuario.Email,
                            foto = x.Usuario.Foto,
                            tipousuario = x.Usuario.TipoUsuario
                        }).ToArray()
                    }; 

                    return Ok(retornoEvento);
                }
                else return NotFound();

            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarporareatuacao/{id}")]
        [Route("buscarporareatuacao/{id}")]
        public IActionResult BurcarEventoPorAreaAtuacao(int id){
            try{
                var evento = _EventoRepository.Listar(new string[]{"Local","UsuariosEventos","Empresa","Empresa.AreaAtuacao"}).Where(x => x.Empresa.AreaAtuacaoId == id).ToList();
                if(evento != null) 
                {
                    var retornoEvento = evento.Select(x =>  new {
                        id = x.Id,
                        nome = x.Nome,
                        foto = x.Foto
                    }).ToList();
                    return Ok(retornoEvento);
                }
                else return NotFound();
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /cadastrar
        ///     {
        ///         "nome" : "nome evento",
        ///         "descricao" : "descricao evento",
        ///         "foto" : "foto do evento",
        ///         "datahora" : "2018-05-07 14:00:00",
        ///         "empresaid" : 1,
        ///         "local" : {
        ///             "logradouro" : "logradouro do evento",
        ///             "numero" : "numero do evento",
        ///             "bairro" : "bairro do evento",
        ///             "cidade" : "cidade do evento",
        ///             "estado" : "estado do evento",
        ///             "cep" : "cep do evento"
        ///         }
        ///     }
        /// 
        /// </remarks>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody]EventoDomain evento){
            List<ModelError> allErrors = new List<ModelError>();
            
            try{

                if(!ModelState.IsValid){
                    allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    return BadRequest(allErrors);
                }

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