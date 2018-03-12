using System.ComponentModel.DataAnnotations;

namespace eaton.agir.domain.Entities
{
    public class Empresa:BaseDomain
    {
        [Required]
        public string RazaoSocial{ get; set; }
[Required]
        public AreaAtuacaoDomain AreaAtuacao { get; set; }
        [Required]
        public AreaInteresseDomain AreaInteresse{get;set;}
[Required]
        public string Cnpj { get; set; }
    }
}