using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Dominio.Contratos.Criptografia;
using Projeto.Web.Excecoes;

namespace Projeto.Dominio.Servicos
{
    public class UsuarioServicoDominio : BaseServicoDominio<Usuario, int>, IUsuarioServicoDominio
    {
        private readonly IUsuarioRepositorio uRep;
        private readonly IParticipacaoRepositorio paRep;
        private readonly ICriptografiaUtil criptografia;

        public UsuarioServicoDominio(IUsuarioRepositorio uRep, IParticipacaoRepositorio paRep, ICriptografiaUtil criptografia) 
            : base(uRep)
        {
            this.uRep = uRep;
            this.paRep = paRep;
            this.criptografia = criptografia;
        }

        public Usuario Autenticar(string email, string senha)
        {
            //criptografar a senha..
            senha = criptografia.EncriptarSenha(senha);
            email = email.ToUpper();

            Usuario u = uRep.ObterPorEmailSenha(email, senha);

            if (u != null)
            {
                return u;
            }
            else
            {
                throw new CustomException("Login e/ou Senha inválido.");
            }
        }

        //sobreescrevendo o atualizar
        public override void Atualizar(Usuario u)
        {
            try
            {
                uRep.BeginTrasaction();

                //Excluindo todos os projetos participados
                paRep.ExcluirParticipacoes(u);

                //Gravando selecionados
                foreach (Participacao pa in u.Participacoes)
                {
                    paRep.Inserir(pa);
                }

                //Encriptografando a senha
                u.Senha = criptografia.EncriptarSenha(u.Senha);


                //Atualizando o cadastro
                uRep.Atualizar(u);

                uRep.Commit();
            }
            catch (Exception ex)
            {
                uRep.Rollback();
                throw new Exception(ex.Message);
            }
        }
       
       
    }
}
