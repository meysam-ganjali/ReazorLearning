using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Data;

public class DataBaseContext : IdentityDbContext<IdentityUser>
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodType> FoodTypes { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
