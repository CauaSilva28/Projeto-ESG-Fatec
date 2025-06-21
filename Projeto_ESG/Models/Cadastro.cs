using System.ComponentModel.DataAnnotations; // Código necessário para utilização das DataAnnotations (validação de dados)

namespace Projeto_ESG.Models
{
    public class Cadastro // Classe que representa a tabela de cadastro do usuário
    {
        [Required] // Indica que o campo é obrigatório
        public string Nome { get; set; }

        [Required]
        [EmailAddress] // Valida se o campo é um endereço de email válido
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Senha curta! Deve conter ao menos 6 caracteres.")] // Define um valor mínimo de caracteres com mensagem de erro
        public string Senha { get; set; }
    }
}

