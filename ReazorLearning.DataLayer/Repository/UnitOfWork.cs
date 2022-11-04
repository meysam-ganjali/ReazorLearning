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
        Category = new CategoryRepository(_db);
        FoodType = new FoodTypeRepository(_db);
        MenuItem = new MenuItemRepository(_db);
        ShoppingCart = new ShoppingCartRepository(_db);
        OrderHeader = new OrderHeaderRepository(_db);
        OrderDetail = new OrderDetailRepository(_db);
        ApplicationUser = new ApplicationUserRepository(_db);
    }

    public ICategoryRepository Category { get; private set; }
    public IFoodTypeRepository FoodType { get; private set; }
    public IMenuItemRepository MenuItem { get; private set; }
    public IShoppingCartRepository ShoppingCart { get; private set; }
    public IOrderHeaderRepository OrderHeader { get; private set; }
    public IOrderDetailRepository OrderDetail { get; private set; }
    public IApplicationUserRepository ApplicationUser { get; private set; }
    public void Save()
    {
        _db.SaveChanges();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}