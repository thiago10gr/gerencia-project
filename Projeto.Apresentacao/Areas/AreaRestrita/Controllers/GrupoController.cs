using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using Projeto.Apresentacao.Areas.AreaRestrita.Security;
using System.Web.Mvc;


namespace Projeto.Apresentacao.Areas.AreaRestrita.Controllers
{
    public class GrupoController : Controller
    {

        [PermissoesFiltro(Roles = "Administrador")]
        public ActionResult Cadastro()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "Administrador")]
        public ActionResult Consulta()
        {
            return View();
        }
    }
}