using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Aplicacao.Contratos;
using Projeto.Dominio.Contratos.Servicos;

namespace Projeto.Aplicacao.Servicos
{
    public abstract class BaseAplicacao<TEntity, TKey> : IBaseAplicacao<TEntity, TKey> where TEntity : class
    {

        private readonly IBaseServicoDominio<TEntity, TKey> dominio;


        public BaseAplicacao(IBaseServicoDominio<TEntity, TKey> dominio)
        {
            this.dominio = dominio;
        }


        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }

        public void Excluir(TEntity obj)
        {
            dominio.Excluir(obj);
        }

        public List<TEntity> ListarTodos()
        {
            return dominio.ListarTodos();
        }

        public TEntity ObterPorId(TKey id)
        {
            return dominio.ObterPorId(id);
        }
    }
}
