using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class Empresa : BaseDomain
    {
        [Required]
        public string RazaoSocial { get; set; }

        [ForeignKey(" AreaAtuacaoId")]
        public AreaAtuacaoDomain AreaAtuacao { get; set; }
        public int AreaAtuacaoId { get; set; }
        [ForeignKey("AreaInteresseId")]
        public AreaInteresseDomain AreaInteresse { get; set; }
        [ForeignKey("enderecoId")]
        public Endereco endereco{get;set;}
        public int enderecoId{get;set;}
        public int AreaInteresseId { get; set; }
        [Required]
        public string Cnpj { get; set; }
    }
}