using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Projeto.Entidades.Tipos;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Projeto.Apresentacao.Areas.AreaRestrita.Validators;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Models
{
    public class UsuarioViewModelPerfil
    {

        [UploadFotoValidator(ErrorMessage = "Por favor, envie apenas imagens jpg de até 50Kb.")]
        [Display(Name = "Foto")]
        public HttpPostedFileBase Foto { get; set; }

        [Display(Name = "Foto")]
        public byte[] Avatar { get; set; }

        [Required(ErrorMessage = "Informe o ID do usuário")]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o senha")]
        public string Senha { get; set; }
        
        [Required(ErrorMessage = "Repita a senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ReSenha { get; set; }

        [Required(ErrorMessage = "Informe se está ativo ou não")]
        public SimNao Ativo { get; set; }

        [Required(ErrorMessage = "Informe o perfil")]
        public Perfil Perfil { get; set; }

        public DateTime DataCadastro { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "Selecione o Grupo")]
        [Display(Name = "Grupo")] 
        public int IdGrupo { get; set; }

        public List<SelectListItem> ListagemGrupos { get; set; }
        public List<ProjetoViewModelConsulta> ListagemProjetos { get; set; }
    }

}
