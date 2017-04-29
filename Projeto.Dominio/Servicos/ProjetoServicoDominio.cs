using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;

namespace Projeto.Dominio.Servicos
{
    public class ProjetoServicoDominio : BaseServicoDominio<Projeto.Entidades.Projeto, int>, IProjetoServicoDominio
    {


        private readonly IProjetoRepositorio repositorio;



        public ProjetoServicoDominio(IProjetoRepositorio repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }



        public List<Entidades.Projeto> ListarPorGrupo(Grupo g)
        {
            return repositorio.ListarPorGrupo(g);
        }


    }
}
