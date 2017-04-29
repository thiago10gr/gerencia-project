using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projeto.Aplicacao.Contratos;
using Projeto.Apresentacao.Areas.AreaRestrita.Security;
using Projeto.Entidades;
using Projeto.Apresentacao.Areas.AreaRestrita.Models;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioAplicacao appUsuario;
        private readonly IGrupoAplicacao appGrupo;
        private readonly IProjetoAplicacao appProjeto;
        private readonly IParticipacaoAplicacao appParticipacao;

        public UsuarioController(IUsuarioAplicacao appUsuario, IGrupoAplicacao appGrupo, IProjetoAplicacao appProjeto, IParticipacaoAplicacao appParticipacao)
        {
            this.appUsuario = appUsuario;
            this.appGrupo = appGrupo;
            this.appProjeto = appProjeto;
            this.appParticipacao = appParticipacao;
        }

        public ActionResult Index()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "Administrador")]
        public ActionResult Projetos()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "Administrador")]
        public ActionResult Funcionarios()
        {
            return View();
        }

        [PermissoesFiltro(Roles = "Administrador, Gerente, Colaborador")]
        public ActionResult Perfil()
        {
            return View(CarregarDadosUsuario());
        }

        private UsuarioViewModelPerfil CarregarDadosUsuario()
        {
            Usuario usuarioSessao = (Usuario)Session["usuario"];
            Usuario u = appUsuario.ObterPorId(usuarioSessao.IdUsuario);

            UsuarioViewModelPerfil model = new UsuarioViewModelPerfil();
            model.ListagemGrupos = new List<SelectListItem>();

            model.IdUsuario = u.IdUsuario;
            model.Nome = u.Nome;
            model.Email = u.Email;
            model.Telefone = u.Telefone;
            model.Celular = u.Celular;
            model.DataCadastro = u.DataCadastro;

            model.IdGrupo = u.IdGrupo;
            model.Ativo = u.Ativo;
            model.Perfil = u.Perfil;


            foreach (Grupo g in appGrupo.ListarAtivos())
            {
                SelectListItem item = new SelectListItem();

                item.Text = g.Nome;
                item.Value = g.IdGrupo.ToString();
               
                model.ListagemGrupos.Add(item);
            }

    
            model.ListagemProjetos = new List<ProjetoViewModelConsulta>();

            foreach (var p in appProjeto.ListarTodos())
            {
                model.ListagemProjetos.Add(new ProjetoViewModelConsulta()
                {
                    IdProjeto = p.IdProjeto,
                    Nome = p.Nome,
                    DataInicio = p.DataInicio,
                    DataFim = p.DataFim,
                    Status = p.Status
                });
            }

            foreach (var pa in appParticipacao.ListarPorUsuario(model.IdUsuario))
            {
                var item = model.ListagemProjetos.FirstOrDefault(p => p.IdProjeto == pa.IdProjeto);
                if (item != null)
                {
                    item.Selecionado = true;
                }
            }

            return model;
        }

        [HttpPost]
        public ActionResult Perfil(UsuarioViewModelPerfil model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario();

                    u.IdUsuario = model.IdUsuario;
                    u.Nome = model.Nome.ToUpper();
                    u.Email = model.Email.ToUpper();
                    u.Telefone = model.Telefone;
                    u.Celular = model.Celular;
                    u.DataCadastro = model.DataCadastro;
                    u.IdGrupo = model.IdGrupo;
                    u.Ativo = model.Ativo;
                    u.Perfil = model.Perfil;
                    u.Senha = model.Senha;

                    model.ListagemProjetos = new List<ProjetoViewModelConsulta>();

                    foreach (var p in appProjeto.ListarTodos())
                    {
                        model.ListagemProjetos.Add(new ProjetoViewModelConsulta()
                        {
                            IdProjeto = p.IdProjeto,
                            Nome = p.Nome,
                            DataInicio = p.DataInicio,
                            DataFim = p.DataFim,
                            Status = p.Status
                        });
                    }

                    foreach (var projeto in model.ListagemProjetos)
                    {
                        Participacao pa = new Participacao()
                        {
                            IdUsuario = u.IdUsuario,
                            IdProjeto = projeto.IdProjeto
                        };

                        if (appParticipacao.RegistroExistente(pa.IdProjeto, pa.IdUsuario))
                        {
                            appParticipacao.Excluir(pa);
                        }
                    }

                    foreach (var idProjeto in Request.Form.GetValues("projetos"))
                    {
                        appParticipacao.Cadastrar(
                                new Participacao()
                                {
                                    IdUsuario = u.IdUsuario,
                                    IdProjeto = int.Parse(idProjeto)
                                }
                            );
                    }

                    appUsuario.Atualizar(u);

                    // Atualiza o Usuário na sessão
                    Session.Add("usuario", u);

                    ViewBag.MsgSucesso = "Usuário atualizado com sucesso.";
                }
                catch (Exception e)
                {
                    ViewBag.MsgErro = "Erro: " + e.Message;
                }
            }

            return View(CarregarDadosUsuario());
        }
    }
}