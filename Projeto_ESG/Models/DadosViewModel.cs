namespace Projeto_ESG.Models;

public class DadosViewModel
{
    public string? Descricao { get; set; } = "";
    public string? CaminhoImagem { get; set; } = "/img/perfil.jpg"; // Adicionando uma imagem padrão inicialmente
    public string? Usuario { get; set; } // Campo ID para identificar o usuário
}