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
           
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Category);
                await _db.SaveChangesAsync();
                TempData["Msg"] = "Categoe Created.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
