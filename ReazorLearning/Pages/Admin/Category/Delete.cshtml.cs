using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.Category
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _category;

        public DeleteModel(ICategoryRepository category)
        {
            _category = category;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.Category Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Category = _category.GetFirstOrDefault(b => b.Id.Equals(id));
            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var category = _category.GetFirstOrDefault(c => c.Id.Equals(Category.Id));
           _category.Remove(category);
           _category.Save();
            TempData["Msg"] = "Category Is Removed";
            return RedirectToPage(nameof(Index));
        }
    }
}
