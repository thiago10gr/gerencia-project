using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projeto.Aplicacao.Contratos;
using Projeto.Apresentacao.Areas.AreaRestrita.Security;
using Projeto.Entidades;
using Projeto.Apresentacao.Areas.AreaRestrita.Models;
using System.IO;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioAplicacao appUsuario;
        private readonly IGrupoAplicacao appGrupo;
        private readonly IProjetoAplicacao appProjeto;
        private readonly IParticipacaoAplicacao appParticipacao;

        public UsuarioController(IUsuarioAplicacao appUsuario, IGrupoAplicacao appGrupo, 
            IProjetoAplicacao appProjeto, IParticipacaoAplicacao appParticipacao)
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
            //obtendo usuario da sessao
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
            model.Avatar = u.Foto;
            model.IdGrupo = u.IdGrupo;
            model.Ativo = u.Ativo;
            model.Perfil = u.Perfil;

            //listar todos os grupos ativos
            foreach (Grupo g in appGrupo.ListarAtivos())
            {
                SelectListItem item = new SelectListItem();

                item.Text = g.Nome;
                item.Value = g.IdGrupo.ToString();
               
                model.ListagemGrupos.Add(item);
            }

            // para listar todos os projetos do sistema
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

            // seleciona os projetos em que o usuario logado esta participando
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

                    u.Participacoes = new List<Participacao>();

                    //verifica se foi selecionado algum projeto na tela de edicao de perfil
                    if (Request.Form.GetValues("projetos") != null)
                    {

                        //obtendo os ids dos projetos selecionados na tela de perfil
                        foreach (var idProjeto in Request.Form.GetValues("projetos"))
                        {
                            u.Participacoes.Add(
                                new Participacao()
                                {
                                    IdUsuario = u.IdUsuario,
                                    IdProjeto = int.Parse(idProjeto)
                                });
                        }
                    }

                    if (model.Foto != null && model.Foto.ContentLength > 0)
                    {
                        Stream stream = model.Foto.InputStream;
                        byte[] appData = new byte[model.Foto.ContentLength + 1];
                        stream.Read(appData, 0, model.Foto.ContentLength);
                        u.Foto = appData;
                        //para exibir na tela
                        model.Avatar = u.Foto;
                    }

                    appUsuario.Atualizar(u);

                    // Atualiza o Usuário na sessão
                    Session.Add("usuario", u);

                    ViewBag.MsgSucesso = $"Usuário {u.Nome}, atualizado com sucesso.";
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