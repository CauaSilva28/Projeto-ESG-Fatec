namespace Projeto_ESG.Models
{
    public class LikeViewModel
    {
        public int? Id { get; set; } = 0;         // ID único do card
        public int? Like { get; set; } = 0;       // Quantidade de curtidas
        public bool Curtido { get; set; } = false; // Se o usuário já curtiu ou não
        public string? DepoimentoComunidade { get; set; } = ""; // Texto dos card depoimento da comunidade
        public string? Usuario { get; set; } = ""; // Nome dos usuarios do card
    }
}