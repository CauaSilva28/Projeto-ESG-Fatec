namespace Projeto_ESG.Models
{
    public class PerfilViewModel
    {
        // Classe com outras classes para serem chamadas na view perfil
        public List<FormViewDepoimento> Depoimentos { get; set; } = new();
        public List<LikeViewModel> Likes { get; set; } = new();
        public DadosViewModel Dados { get; set; } = new();
    }
}