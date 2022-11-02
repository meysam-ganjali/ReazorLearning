using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IFoodTypeRepository : IRepository<FoodType>
{
    void Update(FoodType foodType);
    void Save();
}