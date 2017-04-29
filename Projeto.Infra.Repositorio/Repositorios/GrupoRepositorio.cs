using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;
using Projeto.Entidades.Tipos;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class GrupoRepositorio : BaseRepositorio<Grupo, int>, IGrupoRepositorio
    {


        public List<Grupo> ListarAtivos()
        {
            return contexto.Grupo.Where(g => g.Ativo == SimNao.Sim).ToList();
        }


    }
}
