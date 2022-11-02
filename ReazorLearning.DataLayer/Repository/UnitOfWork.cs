using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Migrations;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.DataLayer.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _db;

    public UnitOfWork(DataBaseContext db)
    {
        _db = db;
        Category = new CategoryRepository(db);
        FoodType = new FoodTypeRepository(db);
    }

    public ICategoryRepository Category { get; private set; }
    public IFoodTypeRepository FoodType { get; private set; }
    public void Save()
    {
        _db.SaveChanges();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}