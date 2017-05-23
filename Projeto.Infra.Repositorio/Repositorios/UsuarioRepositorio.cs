using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, int>, IUsuarioRepositorio
    {



        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            return contexto.Usuario.FirstOrDefault(u => u.Email.Equals(email)
                                                       && u.Senha.Equals(senha));
        }


        public Usuario ObterPorEmail(string email)
        {
            return contexto.Usuario.FirstOrDefault(u => u.Email.Equals(email));
        }


     
    }
}
