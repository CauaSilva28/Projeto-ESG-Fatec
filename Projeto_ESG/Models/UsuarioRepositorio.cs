using System.Collections.Generic;
using System.Linq;
using Projeto_ESG.Models; // Importa as classes

namespace Projeto_ESG
{
    public static class UsuarioRepositorio
    {
        private static List<Usuario> usuarios = new List<Usuario>(); // Lista de usuários

        public static void Adicionar(Usuario usuario) // Função para adicionar um usuário
        {
            usuarios.Add(usuario); 
        }

        public static Usuario BuscarPorEmail(string email) // Função para buscar um usuário pelo email
        {
            return usuarios.FirstOrDefault(u => u.Email == email);
        }

        public static bool Autenticar(string email, string senha) // Função para autenticar o usuário
        {
            var usuario = BuscarPorEmail(email); 
            return usuario != null && usuario.Senha == senha;
        }
    }
}
