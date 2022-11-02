using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.FoodType
{
    public class IndexModel : PageModel
    {
        private readonly IFoodTypeRepository _foodType;

        public IndexModel(IFoodTypeRepository foodType)
        {
            _foodType = foodType;
        }

        public IEnumerable<ReazorLearninig.Models.Models.FoodType> FoodTypes { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            FoodTypes = _foodType.GetAll();
            return Page();
        }
    }
}
