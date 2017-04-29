using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Aplicacao.Contratos;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Entidades;

namespace Projeto.Aplicacao.Servicos
{
    public class ProjetoAplicacao : BaseAplicacao<Projeto.Entidades.Projeto, int>, IProjetoAplicacao
    {


        private readonly IProjetoServicoDominio dominio;

        public ProjetoAplicacao(IProjetoServicoDominio dominio) : base(dominio)
        {
            this.dominio = dominio;
        }



        public List<Entidades.Projeto> ListarPorGrupo(Grupo g)
        {
            return dominio.ListarPorGrupo(g);
        }
    }
}
