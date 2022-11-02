using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.Category
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _category;

        public EditModel(IUnitOfWork category)
        {
            _category = category;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.Category Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Category = _category.Category.GetFirstOrDefault(c => c.Id.Equals(id));
            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var category =  _category.Category.GetFirstOrDefault(c => c.Id.Equals(Category.Id));
           _category.Category.Update(Category);
           _category.Save();
            TempData["Msg"] = "Category Updated";
            return RedirectToPage(nameof(Index));
        }
    }
}
