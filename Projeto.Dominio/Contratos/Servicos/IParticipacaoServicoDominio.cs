using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Dominio.Contratos.Servicos
{
    public interface IParticipacaoServicoDominio : IBaseServicoDominio<Participacao, int>
    {
        bool RegistroExistente(int idProjeto, int idUsuario);

        List<Participacao> ListarPorUsuario(int idUsuario);
    }
}
