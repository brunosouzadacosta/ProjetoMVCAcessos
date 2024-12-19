using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acesso_C_
{
    internal class Log
    {
        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            this.dtAcesso = dtAcesso;
            this.usuario = usuario;
            this.tipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            string status = tipoAcesso ? "Autorizado" : "Negado";
            return $"Data: {dtAcesso}, Usuario: {usuario.Nome}, Tipo: {status}";
        }
    }
}
