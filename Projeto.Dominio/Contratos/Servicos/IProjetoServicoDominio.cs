using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Dominio.Contratos.Servicos
{
    public interface IProjetoServicoDominio : IBaseServicoDominio<Projeto.Entidades.Projeto, int>
    {

        List<Projeto.Entidades.Projeto> ListarPorGrupo(Grupo g);

    }
}
