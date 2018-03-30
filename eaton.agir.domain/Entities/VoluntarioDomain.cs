using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class VoluntarioDomain:BaseDomain
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNasc { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [StringLength(650, MinimumLength = 50)]
        public string Bio{ get; set; }

        [ForeignKey("EnderecoId")]
        public virtual EnderecoDomain Endereco{get;set;}
        public int EnderecoId{get;set;}
        
        [ForeignKey("AreaInteresseId")]
        public virtual AreaAtuacaoDomain AreaInteresse{get;set;}
        public int AreaInteresseId{get;set;}

        [ForeignKey("UsuarioId")]
        public virtual UsuarioDomain Usuario{get;set;}
        public int UsuarioId {get;set;}

        public virtual ICollection<VoluntarioEventoDomain> VoluntariosEventos { get; set; }        
    }
}