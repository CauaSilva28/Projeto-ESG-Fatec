namespace Projeto_ESG.Models
{
    public class PerfilViewModel
    {
        public List<FormViewDepoimento> Depoimentos { get; set; } = new();
        public List<LikeViewModel> Likes { get; set; } = new();
    }
}