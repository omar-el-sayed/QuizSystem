using Microsoft.EntityFrameworkCore;
using QuizSystem.Data;
using QuizSystem.Models;
using System.Linq.Expressions;

namespace QuizSystem.Repository
{
    public class GenericRepository<T>(AppDbContext _context) : IGenericRepository<T> where T : BaseEntity
    {
        public IQueryable<T> GetAll()
            => _context.Set<T>().Where(e => !e.IsDeleted);

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
            => GetAll().Where(predicate);

        public T? GetById(int id)
            => GetAll().FirstOrDefault(e => e.Id == id);

        public T? GetByIdWithTracking(int id)
        {
            return _context.Set<T>()
                .Where(e => !e.IsDeleted && e.Id == id)
                .AsTracking()
                .FirstOrDefault();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
