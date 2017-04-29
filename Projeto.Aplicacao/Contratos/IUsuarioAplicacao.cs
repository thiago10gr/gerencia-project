using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Aplicacao.Contratos
{
    public interface IUsuarioAplicacao : IBaseAplicacao<Usuario, int>
    {
        Usuario Autenticar(string email, string senha);
    }
}
