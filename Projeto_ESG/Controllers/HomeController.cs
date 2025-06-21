using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_ESG.Models;

namespace Projeto_ESG.Controllers;

public class HomeController : Controller // Definindo a controller
{
    private readonly ILogger<HomeController> _logger;

    private static List<FormViewDepoimento> _depoimentoList = new List<FormViewDepoimento>();

    private static List<LikeViewModel> _likes = new List<LikeViewModel>
    {
        new LikeViewModel { Id = 1, Like = 0, Curtido = false, DepoimentoComunidade = "Muito bom!", Usuario = "Ana" },
        new LikeViewModel { Id = 2, Like = 0, Curtido = false, DepoimentoComunidade = "Salvou minha vida!", Usuario = "Maria"},
        new LikeViewModel { Id = 3, Like = 0, Curtido = false, DepoimentoComunidade = "Fiz minha filha baixar kkk, sempre acompanho por onde ela anda, me da um alivio esse aplicativo.", Usuario = "Amanda"}
    };

    private static DadosViewModel _dados = new DadosViewModel();
    private static bool _editavel = true;

    [HttpGet]
    public IActionResult Perfil()
    {
        ViewBag.Editavel = _editavel;

        var viewModel = new PerfilViewModel
        {
            Depoimentos = _depoimentoList,
            Likes = _likes,
            Dados = _dados
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AlterarDados(DadosViewModel dados)
    {
        _dados.Nome = dados.Nome;
        _dados.Descricao = dados.Descricao;
        _editavel = false;
        return RedirectToAction("Perfil");
    }

    [HttpPost]
    public IActionResult EditarDados()
    {
        _editavel = true;
        return RedirectToAction("Perfil");
    }

    [HttpPost]
    public IActionResult Perfil(FormViewDepoimento form)
    {
        if (!string.IsNullOrWhiteSpace(form.Depoimento))
        {
            _depoimentoList.Add(form);
        }

        return Redirect("/Home/Perfil#formDepoimento");
    }

    [HttpPost]
    public IActionResult AdicionarLike(int id)
    {
        var item = _likes.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            if (item.Curtido)
            {
                item.Like--;
                item.Curtido = false;
            }
            else
            {
                item.Like++;
                item.Curtido = true;
            }
        }

        return Redirect("/Home/Perfil#depoimentosComunidade");
    }

    [HttpPost]
    public IActionResult ExcluirDepoimento(string depoimento)
    {
        var item = _depoimentoList.FirstOrDefault(d => d.Depoimento == depoimento);
        if (item != null)
        {
            _depoimentoList.Remove(item);
        }

        return Redirect("/Home/Perfil#formDepoimento");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}