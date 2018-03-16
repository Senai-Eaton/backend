using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class VoluntariosEventosDomain
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("eventoId")]
        public EventoDomain Evento{get;set;}
        public int eventoId{get;set;}

        [ForeignKey("voluntarioId")]
        public VoluntarioDomain Voluntario{get;set;}
        public int voluntarioId{get;set;}



        
        public DateTime Data { get; set; }
    }
}