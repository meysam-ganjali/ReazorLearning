using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ReazorLearning.Pages.Customer.Cart
{
    [Authorize]
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderHeader = new OrderHeader();
        }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public OrderHeader  OrderHeader{ get; set; }
        public void OnGet()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCarts = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserId.Equals(claim.Value),
                    includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");
            }

            foreach (var price in ShoppingCarts)
            {
                OrderHeader.OrderTotal += (price.MenuItem.Price * price.Count);
            }

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == claim.Value);
            OrderHeader.PickupName = applicationUser.FirstName + " " + applicationUser.LastName;
            OrderHeader.PhoneNumber = applicationUser.PhoneNumber;

        }

    }
}
