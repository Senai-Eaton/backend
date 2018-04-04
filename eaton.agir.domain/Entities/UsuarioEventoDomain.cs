using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class UsuarioEventoDomain : BaseDomain
    {
         
        [ForeignKey("EventoId")]
        public virtual EventoDomain Evento{get;set;}
        public int EventoId{get;set;}

        [ForeignKey("UsuarioId")]
        public virtual UsuarioDomain Usuario{get;set;}
        public int UsuarioId{get;set;}

    }
}