using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Aplicacao.Contratos
{
    public interface IParticipacaoAplicacao : IBaseAplicacao<Participacao, int>
    {

        bool RegistroExistente(int idProjeto, int idUsuario);

        List<Participacao> ListarPorUsuario(int idUsuario);
    }
}
