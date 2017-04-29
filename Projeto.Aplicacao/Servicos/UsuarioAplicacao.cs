using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Aplicacao.Contratos;
using Projeto.Entidades;
using Projeto.Dominio.Contratos.Servicos;

namespace Projeto.Aplicacao.Servicos
{
    public class UsuarioAplicacao : BaseAplicacao<Usuario, int>, IUsuarioAplicacao
    {


        private readonly IUsuarioServicoDominio dominio;



        public UsuarioAplicacao(IUsuarioServicoDominio dominio) : base(dominio)
        {
            this.dominio = dominio;
        }


        public Usuario Autenticar(string email, string senha)
        {
            return dominio.Autenticar(email, senha);
        }
    }
}
