using System.Data;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class MenuItemRepository:Repository<MenuItem>,IMenuItemRepository
{
    private readonly DataBaseContext _db;

    public MenuItemRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public void Update(MenuItem menuItem)
    {
        var ObjFromDb = _db.MenuItems.Find(menuItem.Id);
        ObjFromDb.Name = menuItem.Name;
        ObjFromDb.Price = menuItem.Price;
        ObjFromDb.Description = menuItem.Description;
        ObjFromDb.CategoryId = menuItem.CategoryId;
        ObjFromDb.FoodTypeId = menuItem.FoodTypeId;
        if (menuItem.Image != null)
        {
            ObjFromDb.Image = menuItem.Image;
        }

    }
}