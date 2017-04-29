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
    public class AreaServicoDominio : BaseServicoDominio<Area, int>, IAreaServicoDominio
    {


        private readonly IAreaRepositorio repositorio;

        public AreaServicoDominio(IAreaRepositorio repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
