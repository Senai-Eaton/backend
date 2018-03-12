using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class EventoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime DataHora { get; set; }
        [Required]
        public Endereco Local { get; set; }
        
        
    }
}