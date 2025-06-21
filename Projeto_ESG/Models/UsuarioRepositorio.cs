using System.Collections.Generic;
using System.Linq;
using Projeto_ESG.Models; // Importa as classes

namespace Projeto_ESG
{
    public static class UsuarioRepositorio
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static void Adicionar(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public static Usuario BuscarPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email == email);
        }

        public static bool Autenticar(string email, string senha)
        {
            var usuario = BuscarPorEmail(email);
            return usuario != null && usuario.Senha == senha;
        }
    }
}
