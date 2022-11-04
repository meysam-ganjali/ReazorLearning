using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReazorLearninig.Models.Models;

public class OrderDetail
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public OrderHeader OrderHeader { get; set; }

    [Required]
    public int MenuItemId { get; set; }
    [ForeignKey("MenuItemId")]
    public virtual MenuItem MenuItem { get; set; }

    public int Count { get; set; }
    [Required]
    public double Price { get; set; }
    public string Name { get; set; }
}