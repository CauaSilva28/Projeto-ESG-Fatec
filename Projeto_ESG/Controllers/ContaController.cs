using Microsoft.AspNetCore.Mvc;
using Projeto_ESG.Models;
using Projeto_ESG.Controllers;

namespace Projeto_ESG.Controllers
{
    public class ContaController : Controller // Definindo a controller
    {
        public IActionResult Cadastro() // View para exibir o formulário de cadastro
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string Nome, string Email, string Senha) // Método para processar o cadastro
        {
            if (UsuarioRepositorio.BuscarPorEmail(Email) != null)
            {
                ViewBag.Mensagem = "Email já cadastrado.";
                return View();
            }

            UsuarioRepositorio.Adicionar(new Usuario
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha
            });

            TempData["Mensagem"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() // View para exibir o formulário de login
        {
            ViewBag.Mensagem = TempData["Mensagem"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (UsuarioRepositorio.Autenticar(model.Email, model.Senha))
            {
                var usuario = UsuarioRepositorio.BuscarPorEmail(model.Email);
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

                // 🧠 PASSO 4: Verifica se existe imagem de perfil para este usuário
                var pastaPerfis = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/perfis");
                var extensoesPossiveis = new[] { ".jpg", ".png", ".jpeg", ".webp" };
                string? caminhoRelativoImagem = null;

                foreach (var ext in extensoesPossiveis)
                {
                    var nomeArquivo = usuario.Nome + ext;
                    var caminhoCompleto = Path.Combine(pastaPerfis, nomeArquivo);

                    if (System.IO.File.Exists(caminhoCompleto))
                    {
                        caminhoRelativoImagem = "/img/perfis/" + nomeArquivo;
                        break;
                    }
                }

                // Define a imagem encontrada ou uma padrão
                HomeController._dados.CaminhoImagem = caminhoRelativoImagem ?? "/img/perfil.jpg";
                HomeController._dados.Descricao = ""; 

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            HomeController._dados = new DadosViewModel();
            HomeController._editavel = true;

            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Conta");
        }
    }
}
