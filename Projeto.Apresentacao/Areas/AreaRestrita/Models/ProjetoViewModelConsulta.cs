using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Projeto.Entidades.Tipos;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Models
{
    public class ProjetoViewModelConsulta
    {
        public bool Selecionado { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> DataInicio { get; set; } //Pode estar nulo    
        public Nullable<DateTime> DataFim { get; set; }     //Pode estar nulo
        public Status Status { get; set; }
    }
}