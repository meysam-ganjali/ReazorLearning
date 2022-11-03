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
    public void Update(ShoppingCart shoppingCart)
    {
        throw new NotImplementedException();
    }
}