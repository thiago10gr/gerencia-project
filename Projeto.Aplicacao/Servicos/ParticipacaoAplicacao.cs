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
    public class ParticipacaoAplicacao : BaseAplicacao<Participacao, int>, IParticipacaoAplicacao
    {


        private readonly IParticipacaoServicoDominio dominio;


        public ParticipacaoAplicacao(IParticipacaoServicoDominio dominio) : base(dominio)
        {
            this.dominio = dominio;
        }

        public bool RegistroExistente(int idProjeto, int idUsuario)
        {
            return dominio.RegistroExistente(idProjeto, idUsuario);
        }

        public List<Participacao> ListarPorUsuario(int idUsuario)
        {
            return dominio.ListarPorUsuario(idUsuario);
        }
    }
}
