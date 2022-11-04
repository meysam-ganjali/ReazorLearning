using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ReazorLearning.Utilities;

namespace ReazorLearning.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderHeader = new OrderHeader();
        }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public OrderHeader OrderHeader { get; set; }

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

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCarts = _unitOfWork.ShoppingCart.GetAll(filter: u => u.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");

                foreach (var cartItem in ShoppingCarts)
                {
                    OrderHeader.OrderTotal += (cartItem.MenuItem.Price * cartItem.Count);
                }

                OrderHeader.Status = SD.StatusPending;
                OrderHeader.OrderDate = System.DateTime.Now;
                OrderHeader.UserId = claim.Value;
                OrderHeader.PickUpTime = Convert.ToDateTime(OrderHeader.PickUpDate.ToShortDateString() + " " +
                                                            OrderHeader.PickUpTime.ToShortTimeString());
                _unitOfWork.OrderHeader.Add(OrderHeader);
                _unitOfWork.Save();

                foreach (var item in ShoppingCarts)
                {
                    OrderDetail orderDetails = new()
                    {
                        MenuItemId = item.MenuItemId,
                        OrderId = OrderHeader.Id,
                        Name = item.MenuItem.Name,
                        Price = item.MenuItem.Price,
                        Count = item.Count
                    };
                    _unitOfWork.OrderDetail.Add(orderDetails);

                }

                _unitOfWork.ShoppingCart.RemoveRange(ShoppingCarts);
                _unitOfWork.Save();
                return RedirectToPage("/Customer/Home/Index");

            }
            return Page();
        }
    }
}
