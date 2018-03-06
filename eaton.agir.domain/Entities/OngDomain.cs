namespace eaton.agir.domain.Entities
{
    public class OngDomain:BaseDomain
    {
        public string RazaoSocial{ get; set; }
        public AreaAtuacaoDomain AreaAtuacao { get; set; }
        public AreaInteresseDomain AreaInteresse{get;set;}
        public string Cnpj { get; set; }

    }
}