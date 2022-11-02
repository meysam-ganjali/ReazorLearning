using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext _db;

        public CreateModel(DataBaseContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.FoodType FoodType { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _db.FoodTypes.Add(FoodType);
                await _db.SaveChangesAsync();
                TempData["Msg"] = "Food Type Created.";
                return RedirectToPage(nameof(Index));
            }

            return Page();
        }
    }
}
