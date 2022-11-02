using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class FoodTypeRepository : Repository<FoodType> , IFoodTypeRepository
{
    private readonly DataBaseContext _db;

    public FoodTypeRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public void Update(FoodType foodType)
    {
        var ObjFromDb = _db.FoodTypes.FirstOrDefault(c => c.Id.Equals(foodType.Id));
        ObjFromDb.Name = foodType.Name;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}