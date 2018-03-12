using System;
using System.ComponentModel.DataAnnotations;

namespace eaton.agir.domain.Entities
{
    public class VoluntarioDomain:BaseDomain
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNasc { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Profissao{ get; set; }
        [Required]
        public AreaInteresseDomain Area{get;set;}



        
    }
}