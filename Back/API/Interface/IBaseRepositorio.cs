using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Interface
{
    public interface IBaseRepositorio<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> ObterTodos();

        Task<T> ObterPorId(long id);

        Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> predicate);
        Task<T> ObterOnde(Expression<Func<T, bool>> predicate);

        Task<T> Adicionar(T entity);

        Task<T> Atualizar(T entity);

        Task<T> Desabilitar(T entity);

        Task<T> Habilitar(T entity);

        Task<T> Deletar(T entity);
    }
}
