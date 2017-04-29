using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Contratos.Repositorios
{
    public interface IBaseRepositorio<TEntity, TKey> where TEntity : class
    {
        #region Médodos de CRUD

        void Inserir(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> ListarTodos();
        TEntity ObterPorId(TKey id);

        #endregion


        #region Gerenciamento de Trasações

        void BeginTrasaction();
        void Commit();
        void Rollback();
        void Dispose();

        #endregion
    }
}
