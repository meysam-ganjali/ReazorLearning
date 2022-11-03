using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class ShoppingCartRepository:Repository<ShoppingCart>, IShoppingCartRepository
{
    private readonly DataBaseContext _db;

    public ShoppingCartRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public int DecrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Count -= count;
        _db.SaveChanges();
        return shoppingCart.Count;
    }

    public int IncrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Count += count;
        _db.SaveChanges();
        return shoppingCart.Count;
    }
}