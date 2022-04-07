using API.Contexto;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Security.Claims;

namespace API.Repositorio
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : Base
    {
        #region Fields

        protected AcademiaContext _context;
        private long _usuarioId = 0;

        #endregion Fields

        #region Constructor

        public BaseRepositorio(AcademiaContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _usuarioId = Convert.ToInt64(accessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }

        #endregion Constructor

        #region Dispose

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        #endregion Dispose

        public virtual async Task<IEnumerable<T>> ObterTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(long id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> ObterTodosOnde(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public virtual async Task<T> ObterOnde(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> Adicionar(T entity)
        {
            entity.UsuarioIdCadastro = _usuarioId;
            entity.DataCadastro = DateTime.Now;
            entity.Status = true;

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Atualizar(T entity)
        {
            var existente = await _context.Set<T>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (existente != null)
            {
                entity.UsuarioIdAtualizado = _usuarioId;
                entity.DataAtualizado = DateTime.Now;
                _context.Entry(existente).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return existente;
        }

        public async Task<T> Desabilitar(T entity)
        {
            entity.UsuarioIdInativado = _usuarioId;
            entity.DataInativado = DateTime.Now;
            entity.Status = false;

            return await Atualizar(entity);
        }

        public async Task<T> Habilitar(T entity)
        {
            entity.UsuarioIdReativado = _usuarioId;
            entity.DataReativado = DateTime.Now;
            entity.Status = true;

            return await Atualizar(entity);
        }

        public async Task<T> Deletar(T entity)
        {
            var existente = await _context.Set<T>().Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
            if (existente != null)
            {
                _context.Set<T>().Remove(existente);
                await _context.SaveChangesAsync();
            }
            return existente;
        }
    }
}
