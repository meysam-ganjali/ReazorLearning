using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class EditModel : PageModel
    {
        private readonly DataBaseContext _db;

        public EditModel(DataBaseContext db)
        {
            _db = db;
        }
        [BindProperty] 
        public ReazorLearninig.Models.Models.FoodType FoodType { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
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
           var foodType = await _db.FoodTypes.FirstOrDefaultAsync(f => f.Id.Equals(FoodType.Id));
           foodType.Name = FoodType.Name;
           await _db.SaveChangesAsync();
           TempData["Msg"] = "Food Type Updated.";
           return RedirectToPage(nameof(Index));
        }
    }
}
