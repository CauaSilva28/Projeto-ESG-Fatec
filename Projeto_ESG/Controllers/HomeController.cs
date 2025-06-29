using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_ESG.Models;

namespace Projeto_ESG.Controllers
{
    public class HomeController : Controller // Definindo a controller
    {
        private static List<FormViewDepoimento> _depoimentoList = new List<FormViewDepoimento>();

        private static List<LikeViewModel> _likes = new List<LikeViewModel>
    {
        new LikeViewModel { Id = 1, Like = 0, Curtido = false, DepoimentoComunidade = "Muito bom!", Usuario = "Ana" },
        new LikeViewModel { Id = 2, Like = 0, Curtido = false, DepoimentoComunidade = "Salvou minha vida!", Usuario = "Maria"},
        new LikeViewModel { Id = 3, Like = 0, Curtido = false, DepoimentoComunidade = "Fiz minha filha baixar kkk, sempre acompanho por onde ela anda, me da um alivio esse aplicativo.", Usuario = "Amanda"}
    }; // Lista com dados provisórios de usuarios para adicionar nos depoimentos usuarios na view

        public static DadosViewModel _dados = new DadosViewModel();
        public static bool _editavel = true;

        [HttpGet]
        public IActionResult Perfil()
        {
            ViewBag.Editavel = _editavel;

            // Cria e envia o modelo com os dados para a view
            var viewModel = new PerfilViewModel
            {
                Depoimentos = _depoimentoList,
                Likes = _likes,
                Dados = _dados
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AlterarDados(string descricao, IFormFile FotoPerfil)
        {
            var usuario = HttpContext.Session.GetString("UsuarioNome") ?? "usuario"; // Nome do usuário da sessão
            var pastaPerfis = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/perfis");

            if (FotoPerfil != null && FotoPerfil.Length > 0)
            {
                var extensao = Path.GetExtension(FotoPerfil.FileName);
                var nomeArquivo = $"{usuario}{extensao}"; // Faz com que o nome do arquivo seja o nome do usuario para melhor organizacao
                var caminhoCompleto = Path.Combine(pastaPerfis, nomeArquivo); // caminho ao qual ira a imagem adicionada

                if (System.IO.File.Exists(caminhoCompleto))
                {
                    System.IO.File.Delete(caminhoCompleto);
                }

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    FotoPerfil.CopyTo(stream);
                }

                _dados.CaminhoImagem = "/img/perfis/" + nomeArquivo;
            }

            _dados.Descricao = descricao;
            _editavel = false;

            return RedirectToAction("Perfil");
        }

        [HttpPost]
        public IActionResult EditarDados()
        {
            _editavel = true;
            return RedirectToAction("Perfil");
        } //Função que ao clicar no botao editar, torna os dados do perfil editavel

        [HttpPost]
        public IActionResult Perfil(FormViewDepoimento form)
        {
            if (!string.IsNullOrWhiteSpace(form.Depoimento))
            {
                _depoimentoList.Add(form);
            }

            return Redirect("/Home/Perfil#formDepoimento");
        } // Adiciona os depoimentos feitos pelos usuarios na view

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
        } // Função que ao clicar no icone de coração na view, soma mais um e deixa a variavel curtido true

        [HttpPost]
        public IActionResult ExcluirDepoimento(string depoimento)
        {
            var item = _depoimentoList.FirstOrDefault(d => d.Depoimento == depoimento);
            if (item != null)
            {
                _depoimentoList.Remove(item);
            }

            return Redirect("/Home/Perfil#formDepoimento");
        } // Excluir depoimentos na view ao clicar no botão e remove-los da lista



        public IActionResult Index()
        {
            return View(); // Renderiza a View
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
}