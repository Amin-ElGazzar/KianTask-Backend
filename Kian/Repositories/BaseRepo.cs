using Kian.Context;
using Kian.Contract.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Kian.Repositories;

public class BaseRepo<T> : IBaseRepo<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public virtual async Task<T> CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public virtual void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
}
