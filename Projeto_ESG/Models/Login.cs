using System.ComponentModel.DataAnnotations;

namespace Projeto_ESG.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
