using Microsoft.EntityFrameworkCore;
using ReazorLearninig.Models.Models;

namespace ReazorLearning.DataLayer.Data;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodType> FoodTypes { get; set; }
}