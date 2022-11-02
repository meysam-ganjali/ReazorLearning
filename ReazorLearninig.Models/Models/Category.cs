using System.ComponentModel.DataAnnotations;

namespace ReazorLearninig.Models.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1,100,ErrorMessage = "DisplayOrder must be in Rahge 1-100")]
    public int DisplayOrder { get; set; }
    
}