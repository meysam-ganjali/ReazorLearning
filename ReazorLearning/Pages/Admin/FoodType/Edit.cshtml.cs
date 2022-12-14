using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _foodType;

        public EditModel(IUnitOfWork foodType)
        {
            _foodType = foodType;
        }
        [BindProperty] 
        public ReazorLearninig.Models.Models.FoodType FoodType { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            FoodType = _foodType.FoodType.GetFirstOrDefault(c => c.Id.Equals(id));
            if (FoodType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           var foodType = _foodType.FoodType.GetFirstOrDefault(f => f.Id.Equals(FoodType.Id));
           _foodType.FoodType.Update(FoodType);
           _foodType.Save();
           TempData["Msg"] = "Food Type Updated.";
           return RedirectToPage(nameof(Index));
        }
    }
}
