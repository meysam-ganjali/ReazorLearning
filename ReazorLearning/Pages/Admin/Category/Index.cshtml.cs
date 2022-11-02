using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _category;

        public IndexModel(IUnitOfWork category)
        {
            _category = category;
        }

        public IEnumerable<ReazorLearninig.Models.Models.Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = _category.Category.GetAll();
           
            return Page();
        }
    }
}
