using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface IMenuItemRepository : IRepository<MenuItem>
{
    void Update(MenuItem menuItem);
}