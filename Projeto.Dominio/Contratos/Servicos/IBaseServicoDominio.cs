using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Dominio.Contratos.Servicos
{
    public interface IBaseServicoDominio<TEntity, TKey> where TEntity : class
    {
        void Cadastrar(TEntity obj);

        void Atualizar(TEntity obj);

        void Excluir(TEntity obj);

        List<TEntity> ListarTodos();

        TEntity ObterPorId(TKey id);

    }
}
