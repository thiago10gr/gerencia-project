using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Projeto.Entidades.Tipos;


namespace Projeto.Apresentacao.Areas.AreaRestrita.Models
{
    public class GrupoViewModelConsulta
    {
        public int IdGrupo { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public SimNao Ativo { get; set; }
    }
}