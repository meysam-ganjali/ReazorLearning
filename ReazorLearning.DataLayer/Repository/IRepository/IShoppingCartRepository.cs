using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
}