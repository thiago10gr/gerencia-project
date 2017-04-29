using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Projeto.Dominio.Contratos.Servicos;
using Projeto.Entidades;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Dominio.Servicos
{
    public class GrupoServicoDominio : BaseServicoDominio<Grupo, int>, IGrupoServicoDominio
    {


        private readonly IGrupoRepositorio repositorio;


        public GrupoServicoDominio(IGrupoRepositorio repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }



        public List<Grupo> ListarAtivos()
        {
            return repositorio.ListarAtivos();
        }
    }
}
