using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class EnderecoDomain : BaseDomain
    {

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }
        
        [Required]
        public string Bairro { get; set; }
        
        [Required]
        public string Cidade { get; set; }
        
        [Required]
        public string Estado { get; set; }
        
        public string Cep { get; set; }
    }
}