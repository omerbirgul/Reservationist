using System.Linq.Expressions;

namespace App.Repository.GenericRepositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    ValueTask<T?> GetByIdAsync(int id);
    ValueTask CreateAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
}