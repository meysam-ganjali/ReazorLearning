using System.ComponentModel.DataAnnotations.Schema;

namespace ReazorLearninig.Models.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public long Price { get; set; }
    public int FoodTypeId { get; set; }
    [ForeignKey("FoodTypeId")]
    public FoodType FoodType { get; set; }

    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}