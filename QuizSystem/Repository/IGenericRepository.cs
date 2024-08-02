namespace QuizSystem.Repository
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        T? GetById(int id);
        T? GetByIdWithTracking(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}
