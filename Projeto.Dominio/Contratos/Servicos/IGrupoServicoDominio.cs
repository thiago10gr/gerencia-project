﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;

namespace Projeto.Dominio.Contratos.Servicos
{
    public interface IGrupoServicoDominio : IBaseServicoDominio<Grupo, int>
    {
        List<Grupo> ListarAtivos();
    }
}
