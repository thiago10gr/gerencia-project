using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Aplicacao.Contratos;
using Projeto.Dominio.Contratos.Servicos;

namespace Projeto.Aplicacao.Servicos
{
    public class GrupoAplicacao : BaseAplicacao<Grupo, int>, IGrupoAplicacao
    {

        private readonly IGrupoServicoDominio dominio;

        public GrupoAplicacao(IGrupoServicoDominio dominio) : base(dominio)
        {
            this.dominio = dominio;
        }

        public List<Grupo> ListarAtivos()
        {
            return dominio.ListarAtivos();
        }
    }
}
