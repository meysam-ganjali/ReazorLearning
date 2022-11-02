using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly DataBaseContext _db;

    public CategoryRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category category)
    {
        var ObjFromDb = _db.Categories.FirstOrDefault(c => c.Id.Equals(category.Id));
        ObjFromDb.Name = category.Name;
        ObjFromDb.DisplayOrder = category.DisplayOrder;
        Save();
    }

    public void Save()
    {
        _db.SaveChanges();
    }
} 