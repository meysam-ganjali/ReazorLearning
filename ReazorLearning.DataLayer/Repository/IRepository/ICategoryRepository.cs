using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
    void Save();
}