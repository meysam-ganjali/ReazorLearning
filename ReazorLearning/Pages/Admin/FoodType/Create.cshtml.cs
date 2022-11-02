using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class CreateModel : PageModel
    {
        private readonly IFoodTypeRepository _foodType;

        public CreateModel(IFoodTypeRepository foodType)
        {
            _foodType = foodType;
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
                _foodType.Add(FoodType);
                _foodType.Save();
                TempData["Msg"] = "Food Type Created.";
                return RedirectToPage(nameof(Index));
            }

            return Page();
        }
    }
}
