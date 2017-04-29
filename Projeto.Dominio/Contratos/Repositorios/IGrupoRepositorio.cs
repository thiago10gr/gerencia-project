using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Dominio.Contratos.Repositorios
{
    public interface IGrupoRepositorio : IBaseRepositorio<Grupo, int>
    {
        List<Grupo> ListarAtivos();

    }
}
