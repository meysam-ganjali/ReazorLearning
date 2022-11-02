using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.DataLayer.Repository;

public class Repository<T> : IRepository<T> where T:class
{
    private readonly DataBaseContext _db;
    internal DbSet<T> dbSet;
    public Repository(DataBaseContext db)
    {
        _db = db;
        this.dbSet = db.Set<T>();
    }
    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
       dbSet.RemoveRange(entities);
       
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query.FirstOrDefault();
    }
}