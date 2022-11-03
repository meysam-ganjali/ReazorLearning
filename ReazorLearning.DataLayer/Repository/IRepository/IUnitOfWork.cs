namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IFoodTypeRepository FoodType { get; }
    IMenuItemRepository MenuItem { get; }
    void Save();
}