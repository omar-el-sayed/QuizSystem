using Microsoft.EntityFrameworkCore;
using QuizSystem.Data;
using QuizSystem.Models;

namespace QuizSystem.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
            => _context.Set<T>().Where(e => !e.IsDeleted);

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
            //return entity;
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
