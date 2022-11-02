using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext _db;

        public DeleteModel(DataBaseContext db)
        {
            _db = db;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.FoodType FoodType { get; set; }
        public async  Task<IActionResult> OnGetAsync(int id)
        {
            FoodType = await _db.FoodTypes.FindAsync(id);
            if (FoodType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var foodType = await _db.FoodTypes.FindAsync(FoodType.Id);
            _db.FoodTypes.Remove(foodType);
            await _db.SaveChangesAsync();
            TempData["Msg"] = "Food Type Deleted.";
            return RedirectToPage(nameof(Index));
        }
    }
}
