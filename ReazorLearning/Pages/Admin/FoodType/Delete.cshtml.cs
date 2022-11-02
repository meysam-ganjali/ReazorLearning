using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodTypeRepository _foodType;

        public DeleteModel(IFoodTypeRepository foodType)
        {
            _foodType = foodType;
        }
        [BindProperty]
        public ReazorLearninig.Models.Models.FoodType FoodType { get; set; }
        public async  Task<IActionResult> OnGetAsync(int id)
        {
            FoodType = _foodType.GetFirstOrDefault(c => c.Id.Equals(id));
            if (FoodType == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var foodType = _foodType.GetFirstOrDefault(c => c.Id.Equals(FoodType.Id));
           _foodType.Remove(foodType);
           _foodType.Save();
            TempData["Msg"] = "Food Type Deleted.";
            return RedirectToPage(nameof(Index));
        }
    }
}
