using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Dominio.Contratos.Criptografia;
using Projeto.Dominio.Excecoes;

namespace Projeto.Dominio.Servicos
{
    public class UsuarioServicoDominio : BaseServicoDominio<Usuario, int>, IUsuarioServicoDominio
    {


        private readonly IUsuarioRepositorio repositorio;
        private readonly ICriptografiaUtil criptografia;




        public UsuarioServicoDominio(IUsuarioRepositorio repositorio, ICriptografiaUtil criptografia)
            : base(repositorio)
        {
            this.repositorio = repositorio;
            this.criptografia = criptografia;
        }





        public Usuario Autenticar(string email, string senha)
        {
            //criptografar a senha..
           // senha = criptografia.EncriptarSenha(senha);
            email = email.ToUpper();

            Usuario u = repositorio.ObterPorEmailSenha(email, senha);

            if (u != null)
            {
                return u;
            }
            else
            {
                throw new AutenticacaoInvalida();
            }


        }
    }
}
