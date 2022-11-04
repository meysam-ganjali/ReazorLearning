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
        throw new NotImplementedException();
    }
}