using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_C_
{
    internal class Ambiente
    {
        private int id;
        private string nome;
        private Queue<Log> logs;

        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.logs = new Queue<Log>();
        }

        public void RegistrarLog(Log log)
        {
            if (logs.Count >= 100)
            {
                logs.Dequeue();
            }
            logs.Enqueue(log);
        }

        public Queue<Log> Logs => logs;
        public int Id => id;
        public string Nome => nome;

        public override string ToString()
        {
            return $"ID: {id}, Nome: {nome}";
        }
    }
}
