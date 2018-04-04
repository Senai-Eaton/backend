using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using eaton.agir.domain.Contracts;
using eaton.agir.domain.Entities;
using eaton.agir.webApi.util;
using eaton.agir.webApi.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;

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
        ///         "email": "email@email.com",
        ///         "senha": "12345"
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
        public IActionResult Autenticar([FromBody] LoginViewModel usuario,[FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations){
            List<ModelError> allErrors = new List<ModelError>();
           

            try
            {
                if(!ModelState.IsValid){
                    allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    return BadRequest(allErrors);
                }

                
                List<UsuarioDomain> lsUsuarios = _usuarioReposiotry.Listar(new string[]{"Voluntario", "Empresa"}).ToList();

                UsuarioDomain usuario_ = lsUsuarios.FirstOrDefault(x => x.Email.ToLower() == usuario.Email.ToLower() && x.Senha == usuario.Senha); // _usuarioReposiotry.Autenticar(usuario.Email, usuario.Senha);

                if(usuario_ == null){
                    return NotFound("E-mail ou Senha inválida");
                }     

                if (usuario_ != null)
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(usuario_.Id.ToString(), "Login"),
                        new[] {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                            new Claim(JwtRegisteredClaimNames.UniqueName, usuario_.Id.ToString()),
                            new Claim("Nome", (usuario_.TipoUsuario == "Empresa" ? usuario_.Empresa.Nome : usuario_.Voluntario.Nome)),
                            new Claim(ClaimTypes.Email, usuario_.Email),
                            new Claim(ClaimTypes.Role,usuario_.TipoUsuario),
                            new Claim("UserId", usuario_.Id.ToString())
                        }
                    );
                

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = tokenConfigurations.Issuer,
                        Audience = tokenConfigurations.Audience,
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity
                    });



                    var token = handler.WriteToken(securityToken);

                    var retornoUsuario = new {
                        nome = (usuario_.TipoUsuario == "Empresa" ? usuario_.Empresa.Nome : usuario_.Voluntario.Nome),
                        email = usuario_.Email,
                        foto = usuario_.Foto,
                        areaid = (usuario_.TipoUsuario == "Empresa" ? usuario_.Empresa.AreaAtuacaoId : usuario_.Voluntario.AreaInteresseId)
                    };

                    var retorno = new
                    {
                        authenticated = true,
                        accessToken = token,
                        message = "OK",
                        tipousuario = usuario_.TipoUsuario,
                        usuario = retornoUsuario
                    };

                return Ok(retorno);
                }
                else
                {
                    var retorno = new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };

                    return BadRequest(retorno);
                }

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
        ///         "tipousuario" : "Empresa",
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
        ///             "datanasc" : "1978-10-28",               
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