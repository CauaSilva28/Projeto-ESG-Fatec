using System.ComponentModel.DataAnnotations; // Código necessário para utilização das DataAnnotations (validação de dados)

namespace Projeto_ESG.Models
{
    public class Login // Classe que representa a tabela de login do usuário
    {
        [Required] // Indica que o campo é obrigatório
        [EmailAddress] // Valida se o campo é um endereço de email válido
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
