using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Data;

public class DataBaseContext : IdentityDbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodType> FoodTypes { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
}