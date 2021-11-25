using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public async Task<IList<Adult>> getAllAdults() //to list all adults
    {
        IQueryable<Adult> asQueryable = Adults.AsQueryable();
        return await asQueryable.ToListAsync();
    }
    
    public async Task<IList<Adult>> getAdult(int? id, string? FirstName, string? LastName,
         string? HairColor, string? EyeColor, int? age,
         int? Weight, int? height, string? Sex)
    {
        IQueryable<Adult> asQueryable = Adults.AsQueryable();
        if (id != null)
        {
            asQueryable = asQueryable.Where(adult => adult.Id == id);
        }
        if (FirstName != null)
        {
            asQueryable = asQueryable.Where(adult => adult.FirstName == FirstName);
        }
        if (LastName != null)
        {
            asQueryable = asQueryable.Where(adult => adult.LastName == LastName);
        }
        if (HairColor != null)
        {
            asQueryable = asQueryable.Where(adult => adult.HairColor == HairColor);
        }
        if (EyeColor != null)
        {
            asQueryable = asQueryable.Where(adult => adult.EyeColor == EyeColor);
        }
        if (age != null)
        {
            asQueryable = asQueryable.Where(adult => adult.Age == age);
        }
        if (Weight != null)
        {
            asQueryable = asQueryable.Where(adult => adult.Weight == Weight);
        }
        if (height != null)
        {
            asQueryable = asQueryable.Where(adult => adult.Height == height);
        }
        if (Sex != null)
        {
            asQueryable = asQueryable.Where(adult => adult.Sex == Sex);
        }
        return await asQueryable.ToListAsync();
    }
    
    public async Task RemoveAdultAsync(int id)
    {
        Adult toRemove = Adults.First(t => t.Id == id);
        Adults.Remove(toRemove);
    }
    
    public async Task<IList<User>> getUser(string? username) //for login
    {
        IQueryable<User> asQueryable = Users.AsQueryable();
        if (username != null)
        {
            asQueryable = asQueryable.Where(user => user.UserName == username);
        }
        return await asQueryable.ToListAsync();
    }

}