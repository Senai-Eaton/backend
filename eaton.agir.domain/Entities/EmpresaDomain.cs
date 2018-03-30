using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class EmpresaDomain : BaseDomain
    {
        [Required]
        [StringLength(150, MinimumLength =3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(650, MinimumLength = 10)]
        public string Descricao{ get; set; }

        [Required]
        [StringLength(150, MinimumLength =3)]
        public string RazaoSocial { get; set; }

        [ForeignKey("AreaAtuacaoId")]
        public virtual AreaAtuacaoDomain AreaAtuacao { get; set; }
        public int AreaAtuacaoId { get; set; }
        
        [ForeignKey("EnderecoId")]
        public virtual EnderecoDomain Endereco{get;set;}
        public int EnderecoId{get;set;}

        [ForeignKey("UsuarioId")]
        public virtual UsuarioDomain Usuario{get;set;}
        public int UsuarioId {get;set;}

        
        [Required]
        public string Cnpj { get; set; }


    }
}