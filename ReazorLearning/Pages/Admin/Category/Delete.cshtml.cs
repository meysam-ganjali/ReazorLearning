using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.Category
{
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext _db;

        public DeleteModel(DataBaseContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.Category Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Category = await _db.Categories.FindAsync(id);
            if (Category == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id.Equals(Category.Id));
           _db.Categories.Remove(category);
            var res = await _db.SaveChangesAsync();
            TempData["Msg"] = "Category Is Removed";
            return RedirectToPage(nameof(Index));
        }
    }
}
