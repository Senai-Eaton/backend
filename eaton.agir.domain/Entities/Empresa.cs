using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class Empresa : BaseDomain
    {
        [Required]
        public string RazaoSocial { get; set; }

        [ForeignKey("AreaAtuacaoiId")]
        public AreaAtuacaoDomain AreaAtuacao { get; set; }
        public int AreaAtuacaoId { get; set; }
        [ForeignKey("AreaInteresseId")]
        public AreaInteresseDomain AreaInteresse { get; set; }
        public int AreaInteresseId { get; set; }
        [Required]
        public string Cnpj { get; set; }
    }
}