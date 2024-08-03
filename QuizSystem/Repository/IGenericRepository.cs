using System.Linq.Expressions;

namespace QuizSystem.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T? GetById(int id);
        T? GetByIdWithTracking(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
