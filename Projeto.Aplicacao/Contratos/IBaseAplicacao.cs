using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Aplicacao.Contratos
{
    public interface IBaseAplicacao<TEntity, TKey>
    {
        void Cadastrar(TEntity obj);

        void Atualizar(TEntity obj);

        void Excluir(TEntity obj);

        List<TEntity> ListarTodos();

        TEntity ObterPorId(TKey id);
    }
}
