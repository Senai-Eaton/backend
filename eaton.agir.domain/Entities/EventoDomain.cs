using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class EventoDomain : BaseDomain
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }
        
        public string Foto { get; set; }
        
        [Required]
        public DateTime DataHora { get; set; }

        [ForeignKey("LocalId")]
        public virtual EnderecoDomain Local { get; set; }
        public int LocalId{get;set;}

        [ForeignKey("EmpresaId")]
        public virtual EmpresaDomain Empresa { get; set; }
        public int EmpresaId{get;set;}
        
        public virtual ICollection<UsuarioEventoDomain> UsuariosEventos { get; set; }
    }
}