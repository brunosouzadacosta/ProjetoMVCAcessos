using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_C_
{
    internal class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool RemoverUsuario(Usuario usuario)
        {
            if (usuario.Ambientes.Count == 0)
            {
                return usuarios.Remove(usuario);
            }
            return false;
        }

        public Usuario PesquisarUsuario(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void AdicionarAmbiente(Ambiente ambiente)
        {
            ambientes.Add(ambiente);
        }

        public bool RemoverAmbiente(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        public Ambiente PesquisarAmbiente(int id)
        {
            return ambientes.FirstOrDefault(a => a.Id == id);
        }

        public void Upload()
        {
            // Implementar persistência (e.g., salvar em banco de dados ou arquivo)
        }

        public void Download()
        {
            // Implementar carregamento (e.g., recuperar de banco de dados ou arquivo)
        }
    }
}
