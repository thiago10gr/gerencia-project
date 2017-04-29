using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario, int>
    {

        Usuario ObterPorEmailSenha(string email, string senha);

        Usuario ObterPorEmail(string email);

    }
}
