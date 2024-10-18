namespace Kian.Contract.Repositories;

public interface IBaseRepo<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    Task<T> GetById(int id);
    T Update(T entity);
    void Delete(T entity);
}
