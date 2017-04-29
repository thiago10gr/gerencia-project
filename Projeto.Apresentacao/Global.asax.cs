using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using SimpleInjector.Integration.Web;
using Projeto.Dominio.Contratos.Repositorios;
using SimpleInjector;
using Projeto.Aplicacao.Servicos;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Servicos;
using Projeto.Aplicacao.Contratos;
using System.Reflection;
using Projeto.Infra.Repositorio.Repositorios;
using SimpleInjector.Integration.Web.Mvc;
using Projeto.Dominio.Contratos.Criptografia;
using Projeto.Infra.Criptografia;
using Projeto.Apresentacao.Areas.AreaRestrita.Security;

namespace Projeto.Apresentacao
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();



            // Register your types, for instance:
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IProjetoRepositorio, ProjetoRepositorio>(Lifestyle.Scoped);
            container.Register<IAreaRepositorio, AreaRepositorio>(Lifestyle.Scoped);
            container.Register<IGrupoRepositorio, GrupoRepositorio>(Lifestyle.Scoped);
            container.Register<IParticipacaoRepositorio, ParticipacaoRepositorio>(Lifestyle.Scoped);



            container.Register<IUsuarioServicoDominio, UsuarioServicoDominio>(Lifestyle.Scoped);
            container.Register<IProjetoServicoDominio, ProjetoServicoDominio>(Lifestyle.Scoped);
            container.Register<IAreaServicoDominio, AreaServicoDominio>(Lifestyle.Scoped);
            container.Register<IGrupoServicoDominio, GrupoServicoDominio>(Lifestyle.Scoped);
            container.Register<IParticipacaoServicoDominio, ParticipacaoServicoDominio>(Lifestyle.Scoped);


            container.Register<IUsuarioAplicacao, UsuarioAplicacao>(Lifestyle.Scoped);
            container.Register<IProjetoAplicacao, ProjetoAplicacao>(Lifestyle.Scoped);
            container.Register<IAreaAplicacao, AreaAplicacao>(Lifestyle.Scoped);
            container.Register<IGrupoAplicacao, GrupoAplicacao>(Lifestyle.Scoped);
            container.Register<IParticipacaoAplicacao, ParticipacaoAplicacao>(Lifestyle.Scoped);

            container.Register<ICriptografiaUtil, CriptografiaUtil>(Lifestyle.Scoped);


            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
