using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail orderDetail);
}