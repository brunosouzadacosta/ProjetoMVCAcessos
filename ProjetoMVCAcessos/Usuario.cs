using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_C_
{
    internal class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.ambientes = new List<Ambiente>();
        }

        public bool ConcederPermissao(Ambiente ambiente)
        {
            if (!ambientes.Contains(ambiente))
            {
                ambientes.Add(ambiente);
                return true;
            }
            return false;
        }

        public bool RevogarPermissao(Ambiente ambiente)
        {
            return ambientes.Remove(ambiente);
        }

        public override string ToString()
        {
            return $"ID: {id}, Nome: {nome}";
        }

        public int Id => id;
        public string Nome => nome;
        public List<Ambiente> Ambientes => ambientes;
    }
}
