using Microsoft.EntityFrameworkCore;
using Models;
using WebApplication.Models;

public class DBContext : DbContext
{
    public DbSet<Adult> Adults { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // name of database
        optionsBuilder.UseSqlite(@"Data Source = C:\Users\samue\Documents\VIA\3rd Semester\DNP\HandIn_3\Adultsdotn.db");
    }
}