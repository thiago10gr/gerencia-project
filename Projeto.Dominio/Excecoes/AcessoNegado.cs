using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Excecoes
{
    public class AcessoNegado : Exception
    {
        public override string Message
        {
            get
            {
                return "Acesso Negado. Tente novamente";
            }
        }
    }
}
