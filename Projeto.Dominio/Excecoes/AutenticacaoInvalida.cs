using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Excecoes
{
    public class AutenticacaoInvalida : Exception
    {
        public override string Message
        {
            get
            {
                return "Email e/ou Senha inválido";
            }
        }
    }
}
