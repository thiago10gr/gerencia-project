using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class AreaRepositorio : BaseRepositorio<Area, int>, IAreaRepositorio
    {
    }
}
