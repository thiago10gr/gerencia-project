using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class ParticipacaoRepositorio : BaseRepositorio<Participacao, int>, IParticipacaoRepositorio
    {

        public bool RegistroExistente(int idProjeto, int idUsuario)
        {
            return contexto.Participacao.Where(p => p.IdProjeto == idProjeto
                                                 && p.IdUsuario == idUsuario).ToList().Count() > 0;


        }

        public List<Participacao> ListarPorUsuario(int idUsuario)
        {
                return contexto.Participacao
                          .Where(p => p.IdUsuario == idUsuario)
                          .ToList();
     
        }

        public void ExcluirParticipacoes(Usuario u)
        {
            contexto.Participacao.RemoveRange(contexto.Participacao.Where(pa => pa.IdUsuario == u.IdUsuario));
            contexto.SaveChanges();
        }
    }
}
