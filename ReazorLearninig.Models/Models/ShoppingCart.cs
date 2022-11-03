using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ReazorLearninig.Models.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    [ForeignKey("MenuItemId")]
    [NotMapped]
    [ValidateNever]
    public MenuItem MenuItem { get; set; }
    [Range(1,100,ErrorMessage = "Please Select a Count Between 1 and 100")]
    public int Count { get; set; }

    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    [NotMapped]
    [ValidateNever]
    public ApplicationUser ApplicationUser { get; set; }
}