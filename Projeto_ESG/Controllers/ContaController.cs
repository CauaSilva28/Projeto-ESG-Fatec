using Microsoft.AspNetCore.Mvc;
using Projeto_ESG.Models;

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
        public IActionResult Login(Login model) // Método para processar o login
        {
            if (!ModelState.IsValid)
                return View(model);

            if (UsuarioRepositorio.Autenticar(model.Email, model.Senha))
            {
                var usuario = UsuarioRepositorio.BuscarPorEmail(model.Email);
                ViewBag.Mensagem = $"Login bem-sucedido. Olá, {usuario.Nome}!";

                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                return View(model); 
            }
        }

        public IActionResult Logout() // Método para processar o logout
        {
            HttpContext.Session.Clear(); // Apaga sessão, ou seja, o nome armazenado do usuário
            return RedirectToAction("Index", "Home"); // Redireciona para a página inicial
        }

    }
}
