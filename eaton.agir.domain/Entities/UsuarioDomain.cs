using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eaton.agir.domain.Entities
{
    public class UsuarioDomain : BaseDomain
    {
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Required]
        [StringLength(250)]
        public string Foto {get;set;}
        
        [Required]
        [StringLength(20)]
        public string TipoUsuario {get;set;}
        public virtual EmpresaDomain Empresa { get; set; }
        public virtual VoluntarioDomain Voluntario { get; set; }
        public virtual ICollection<UsuarioEventoDomain> UsuariosEventos { get; set; }        

    }
}