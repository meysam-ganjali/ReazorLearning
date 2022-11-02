using System.Linq.Expressions;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    IEnumerable<T> GetAll();
    T GetFirstOrDefault(Expression<Func<T,bool>>? filter = null);
}