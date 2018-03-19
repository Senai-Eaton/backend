using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eaton.agir.domain.Entities
{
    public abstract class BaseDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string  email { get; set; }
        [DataType(DataType.Password)]
        public string senha { get; set; }
        [Required]
        public string foto {get;set;}
        [Required]
        public string Token{get;set;}
        
    }
}