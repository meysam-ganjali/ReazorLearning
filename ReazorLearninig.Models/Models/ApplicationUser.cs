using Microsoft.AspNetCore.Identity;

namespace ReazorLearninig.Models.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}