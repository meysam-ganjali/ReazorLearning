using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IOrderHeaderRepository:IRepository<OrderHeader>
{
    void Update(OrderHeader order);
}