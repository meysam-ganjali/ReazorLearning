using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository;

public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
{
    private readonly DataBaseContext _db;

    public OrderDetailRepository(DataBaseContext db) : base(db)
    {
        _db = db;
    }
    public void Update(OrderDetail orderDetail)
    {
        throw new NotImplementedException();
    }
}