using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class IndexModel : PageModel
    {
        private readonly DataBaseContext _db;

        public IndexModel(DataBaseContext db)
        {
            _db = db;
        }

        public IEnumerable<ReazorLearninig.Models.Models.FoodType> FoodTypes { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            FoodTypes = await _db.FoodTypes.ToListAsync();
            return Page();
        }
    }
}
