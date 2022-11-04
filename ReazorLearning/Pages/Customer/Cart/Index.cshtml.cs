using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReazorLearning.DataLayer.Repository.IRepository;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public double TotalPrice { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            TotalPrice = 0;
        }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }

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
                TotalPrice += (price.MenuItem.Price * price.Count);
            }
        }

        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(filter: c => c.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            TempData["Msg"] = "Plus Item In Cart";
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(filter: c => c.Id.Equals(cartId));
            _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
            TempData["Msg"] = "Minus Item In Cart";
            if (cart.Count == 0)
            {
                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();
                TempData["Msg"] = "Remove Item In Cart";
                return RedirectToPage("/Customer/Cart/Index");
            }
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(filter: c => c.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            TempData["Msg"] = "Remove Item In Cart";
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}
