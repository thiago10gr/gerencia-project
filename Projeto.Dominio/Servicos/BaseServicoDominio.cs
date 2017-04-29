using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Dominio.Servicos
{
    public abstract class BaseServicoDominio<TEntity, TKey> : IBaseServicoDominio<TEntity, TKey> where TEntity : class
    {


        private readonly IBaseRepositorio<TEntity, TKey> repositorio;


        //construtor para injeção por dependência
        public BaseServicoDominio(IBaseRepositorio<TEntity, TKey> repositorio)
        {
            this.repositorio = repositorio;
        }



        public void Cadastrar(TEntity obj)
        {
            try
            {
                repositorio.BeginTrasaction();
                repositorio.Inserir(obj);
                repositorio.Commit();

            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }



        public void Atualizar(TEntity obj)
        {
            try
            {
                repositorio.BeginTrasaction();
                repositorio.Atualizar(obj);
                repositorio.Commit();

            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }



        public void Excluir(TEntity obj)
        {
            try
            {
                repositorio.BeginTrasaction();
                repositorio.Excluir(obj);
                repositorio.Commit();

            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }



        public List<TEntity> ListarTodos()
        {
            try
            {
                return repositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public TEntity ObterPorId(TKey id)
        {
            try
            {
                return repositorio.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
