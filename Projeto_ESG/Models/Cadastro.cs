using System.ComponentModel.DataAnnotations;

namespace Projeto_ESG.Models
{
    public class Cadastro
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Senha curta! Deve ter ao menos 6 caracteres.")]
        public string Senha { get; set; }
    }
}

