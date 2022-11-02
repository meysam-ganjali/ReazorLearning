using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;

namespace ReazorLearning.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly DataBaseContext _db;

        public IndexModel(DataBaseContext db)
        {
            _db = db;
        }

        public IEnumerable<ReazorLearninig.Models.Models.Category> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(string order="des")
        {
            if (order == "des")
            {
                Categories = await _db.Categories.OrderByDescending(a => a.DisplayOrder).ToListAsync();
            }

            if (order == "asi")
            {
                 Categories = await _db.Categories.OrderBy(a => a.DisplayOrder).ToListAsync();
            }
           
            return Page();
        }
    }
}
