using System.ComponentModel.DataAnnotations;

namespace eaton.agir.webApi.ViewModels.Usuario
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        
    }
}