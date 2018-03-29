using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class VoluntarioEventoDomain : BaseDomain
    {
         
        [ForeignKey("EventoId")]
        public virtual EventoDomain Evento{get;set;}
        public int EventoId{get;set;}

        [ForeignKey("VoluntarioId")]
        public virtual VoluntarioDomain Voluntario{get;set;}
        public int VoluntarioId{get;set;}

    }
}