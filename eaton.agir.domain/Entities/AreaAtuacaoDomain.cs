using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public class AreaAtuacaoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        [Required]
        
        public string Nome { get; set; }
        

    }



}