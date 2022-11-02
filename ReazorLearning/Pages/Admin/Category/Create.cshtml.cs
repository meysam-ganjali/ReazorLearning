using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext _db;

        public CreateModel(DataBaseContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.Category Category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Category.DisplayOrder < 1)
            {
                ModelState.AddModelError("","DispalyOrder Can Not 0<");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
