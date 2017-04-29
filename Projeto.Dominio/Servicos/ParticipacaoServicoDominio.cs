using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Dominio.Servicos
{
    public class ParticipacaoServicoDominio : BaseServicoDominio<Participacao, int>, IParticipacaoServicoDominio
    {

        private readonly IParticipacaoRepositorio repositorio;

        public ParticipacaoServicoDominio(IParticipacaoRepositorio repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool RegistroExistente(int idProjeto, int idUsuario)
        {
            return repositorio.RegistroExistente(idProjeto, idUsuario);
        }

        public List<Participacao> ListarPorUsuario(int idUsuario)
        {
            return repositorio.ListarPorUsuario(idUsuario);
        }
    }
}
