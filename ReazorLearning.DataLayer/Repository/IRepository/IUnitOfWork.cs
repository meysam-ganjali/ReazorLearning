namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IFoodTypeRepository FoodType { get; }
    IMenuItemRepository MenuItem { get; }
    IShoppingCartRepository ShoppingCart { get; }
    IOrderHeaderRepository OrderHeader { get; }
    IOrderDetailRepository OrderDetail { get; }
    void Save();
}