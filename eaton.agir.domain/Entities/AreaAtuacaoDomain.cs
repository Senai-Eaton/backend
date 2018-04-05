using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class AreaAtuacaoDomain : BaseDomain
    {

        [Required]
        public string Nome { get; set; }
        

    }



}