using System.Collections.Generic;
using System.Linq;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.webApi.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eaton.agir.webApi.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioRepository _usuarioReposiotry;

        public UsuarioController(IUsuarioRepository usuarioReposiotry)
        {
            _usuarioReposiotry = usuarioReposiotry;
        }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/usuario/autenticar
        ///     {
        ///        "email": "email@email.com",
        ///        "senha": "12345"
        ///     }
        ///
        /// </remarks>
        /// <returns>Retorna um usuário</returns>
        /// <response code="201">Retorna os dados do usuário autenticado</response>
        /// <response code="404">Retorna uma string com o erro</response> 
        /// <response code="400">Retorna uma lista de erros</response> 
        [HttpPost]
        [Route("api/usuario/autenticar")]
        [ProducesResponseType(typeof(UsuarioDomain), 201)]
        [ProducesResponseType(typeof(List<ModelError>), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult Autenticar([FromBody] LoginViewModel usuario){
            List<ModelError> allErrors = new List<ModelError>();

            try
            {
                if(!ModelState.IsValid){
                    allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    return BadRequest(allErrors);
                }

                UsuarioDomain usuario_ = _usuarioReposiotry.Autenticar(usuario.Email, usuario.Senha);

                if(usuario_ == null){
                    return NotFound("E-mail ou Senha inválida");
                }

                return Ok(usuario_);

            }
            catch (System.Exception ex)
            {
                allErrors.Add(new ModelError(ex));
                return BadRequest(allErrors);
            }
        }

        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/usuario/cadastrarempresa
        ///     {
        ///         "email": "email@email.com",
        ///         "senha": "12345",
        ///         "foto" : "urldafoto",
        ///         "tipousuario" : "Ong",
        ///         "empresa":{
        ///             "nome" : "nome da empresa",
        ///             "descricao" : "descricao da empresa deve ter no minimo 50 caracteres (até 650 caracteres)",
        ///             "razaosocial" : "nome da empresa",
        ///             "areaatuacaoid" : 1,
        ///             "cnpj" : "454.989.998/0001-54",
        ///             "endereco" : {
        ///                 "logradouro" : "logradouro empresa",
        ///                 "numero" : "numero empresa",
        ///                 "bairro" : "bairro empresa",
        ///                 "cidade" : "cidade empresa",
        ///                 "estado" : "estado empresa",
        ///                 "cep" : "cep empresa"
        ///             }
        ///         }
        ///     }
        /// </remarks>
        /// <returns>Retorna um usuário</returns>
        /// <response code="201">Retorna os dados do usuário cadastrado</response>
        /// <response code="404">Retorna uma string com o erro</response> 
        /// <response code="400">Retorna uma lista de erros</response> 
        [HttpPost]
        [Route("api/usuario/cadastrarempresa")]
        [ProducesResponseType(typeof(UsuarioDomain), 201)]
        [ProducesResponseType(typeof(List<ModelError>), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult CadastrarEmpresa([FromBody] UsuarioDomain usuario){
            List<ModelError> allErrors = new List<ModelError>();

            try
            {
                if(!ModelState.IsValid){
                    allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    return BadRequest(allErrors);
                }

                UsuarioDomain usuario_ = _usuarioReposiotry.VerificaUsuarioExiste(usuario.Email);

                if(usuario_ != null){
                    allErrors.Add(new ModelError("Email já cadastrado"));
                    return BadRequest(allErrors);
                }

                _usuarioReposiotry.Inserir(usuario);
                return Ok(usuario);

            }
            catch (System.Exception ex)
            {
                allErrors.Add(new ModelError(ex));
                return BadRequest(allErrors);
            }
        }


        /// <summary>
        /// Autentica o usuário
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/usuario/cadastrarvoluntario
        ///     {
        ///         "email": "email@email.com",
        ///         "senha": "12345",
        ///         "foto" : "urldafoto",
        ///         "tipousuario" : "Voluntario",
        ///         "voluntario":{
        ///             "nome" : "nome da empresa",
        ///             "datanasc" : "1978-10-28"               
        ///             "cpf" : "543.653.765-665",
        ///             "areainteresseid" : 1,
        ///             "bio" : "Descrição da Bio",
        ///             "endereco" : {
        ///                 "logradouro" : "logradouro empresa",
        ///                 "numero" : "numero empresa",
        ///                 "bairro" : "bairro empresa",
        ///                 "cidade" : "cidade empresa",
        ///                 "estado" : "estado empresa",
        ///                 "cep" : "cep empresa"
        ///             }
        ///         }
        ///     }
        /// </remarks>
        /// <returns>Retorna um usuário</returns>
        /// <response code="201">Retorna os dados do usuário cadastrado</response>
        /// <response code="404">Retorna uma string com o erro</response> 
        /// <response code="400">Retorna uma lista de erros</response> 
        [HttpPost]
        [Route("api/usuario/cadastrarvoluntario")]
        [ProducesResponseType(typeof(UsuarioDomain), 201)]
        [ProducesResponseType(typeof(List<ModelError>), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public IActionResult CadastrarVoluntario([FromBody] UsuarioDomain usuario){
            List<ModelError> allErrors = new List<ModelError>();

            try
            {
                if(!ModelState.IsValid){
                    allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    return BadRequest(allErrors);
                }

                UsuarioDomain usuario_ = _usuarioReposiotry.VerificaUsuarioExiste(usuario.Email);

                if(usuario_ != null){
                    allErrors.Add(new ModelError("Email já cadastrado"));
                    return BadRequest(allErrors);
                }

                _usuarioReposiotry.Inserir(usuario);
                return Ok(usuario);

            }
            catch (System.Exception ex)
            {
                allErrors.Add(new ModelError(ex));
                return BadRequest(allErrors);
            }
        }
    }
}