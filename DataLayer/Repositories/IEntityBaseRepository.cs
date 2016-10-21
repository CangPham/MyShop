using DomainClasses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetSingle(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T updated, int key);
        Task<int> DeleteAsync(T entity);
        int Count();
        int Count(int Id);
        Task<int> CountAsync();
    }
}
