using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data.Impl.Adults
{
    public class AdultsData : IAdults
    {
        private IList<Adult> adults;
        private DBContext ctx;

        public AdultsData()
        {
            ctx = new DBContext();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await ctx.getAllAdults();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        { 
            await ctx.Adults.AddAsync(adult);
            await ctx.SaveChangesAsync();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            ctx.Adults.Remove(ctx.Adults.Single(a => a.Id == adultId));
            await ctx.SaveChangesAsync();
        }

        /*public async Task GetAdult(int id)
        {
            Adult toReturn = adults.First(t => t.Id == id);
            return toReturn;
        }*/

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            Adult toUpdate = adults.FirstOrDefault(a => a.Id == adult.Id);
            if (toUpdate == null) throw new Exception($"Did not find todo with id: {adult.Id}");
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Height = adult.Height;
            toUpdate.Weight = adult.Weight;
            toUpdate.Sex = adult.Sex;
            toUpdate.JobTitle = adult.JobTitle;

            ctx.Adults.Update(toUpdate);
            await ctx.SaveChangesAsync();
            return toUpdate;
        }
        

        private void Seed()
        {
            Adult[] ads =
            {
                new Adult()
                {
                    FirstName = "idk",
                    LastName = "lol",
                    HairColor = "green",
                    EyeColor = "brown",
                    Age = 44,
                    Weight = 49,
                    Height = 174,
                    Sex = "M",
                    JobTitle = {JobTitle = "Mascot", Salary = 99950}
                }

            };
            adults = ads.ToList();
        }
    }
}

/*public void AddAdult(Adult adult)
{
    int max = adults.Max(adult => adult.Id);
    adult.Id = (++max);
    adults.Add(adult);
    fileContext.SaveChanges(adults,false);
}

public void RemoveAdult(int adultId)
{
    Adult adultToRemove = adults.First(a => a.Id == adultId);
    adults.Remove(adultToRemove);
    fileContext.SaveChanges(adults,false);
}

public void Update(Adult adult)
{
    int index = adults.IndexOf(adults.First(a => a.Id == adult.Id));
    adults[index] = adult;
    fileContext.SaveChanges(adults, false);
}
*/

