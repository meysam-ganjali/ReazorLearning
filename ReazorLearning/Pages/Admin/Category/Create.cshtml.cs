using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Data;
using ReazorLearning.DataLayer.Repository.IRepository;

namespace ReazorLearning.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _category;

        public CreateModel(ICategoryRepository category)
        {
            _category = category;
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
               _category.Add(Category);
               _category.Save();
                TempData["Msg"] = "Category Created.";
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }
    }
}
