using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.Pages.Customer.Home
{
    public class DetailesModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailesModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MenuItem MenuItem { get; set; }
        [Range(0,100,ErrorMessage = "Be Must 0 to 100 ")]
        public int Count { get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(filter: u => u.Id.Equals(id),includeProperties:"Category,FoodType");
        }
    }
}
