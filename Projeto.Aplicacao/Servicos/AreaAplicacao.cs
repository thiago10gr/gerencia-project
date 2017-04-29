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
    public class AreaAplicacao : BaseAplicacao<Area, int>, IAreaAplicacao
    {

        private readonly IAreaServicoDominio dominio;

        public AreaAplicacao(IAreaServicoDominio dominio) : base(dominio)
        {
            this.dominio = dominio;
        }
    }
}
