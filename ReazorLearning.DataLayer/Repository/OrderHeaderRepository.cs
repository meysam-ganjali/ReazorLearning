using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
{
    private readonly DataBaseContext _db;

    public OrderHeaderRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public void Update(OrderHeader order)
    {
        _db.OrderHeaders.Update(order);
    }
    public void UpdateStatus(int id, string status)
    {
        var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
        if (orderFromDb != null)
        {
            orderFromDb.Status = status;
        }
    }
}