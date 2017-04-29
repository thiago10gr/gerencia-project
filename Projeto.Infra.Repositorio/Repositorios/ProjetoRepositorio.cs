using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class ProjetoRepositorio : BaseRepositorio<Projeto.Entidades.Projeto, int>, IProjetoRepositorio
    {

        public List<Projeto.Entidades.Projeto> ListarPorGrupo(Grupo g)
        {
            return contexto.Projeto.Where(p => p.IdGrupo == g.IdGrupo).ToList();
        }

    }
}
