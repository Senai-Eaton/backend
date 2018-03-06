using System;

namespace eaton.agir.domain.Entities
{
    public class VoluntarioDomain:BaseDomain
    {
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Cpf { get; set; }
        public string Profissao{ get; set; }
        public AreaInteresseDomain Area{get;set;}



        
    }
}