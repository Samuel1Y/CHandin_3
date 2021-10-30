using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace WebApplication.Data.Impl.Adults
{
    public class AdultsData : IAdults
    {
        private IList<Adult> adults;
        private FileContext fileContext;

        public AdultsData()
        {
            fileContext = new FileContext();
            adults = fileContext.Adults;
        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> list = new List<Adult>(adults);
            return list;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.id);
            adult.id = (++max);
            adults.Add(adult);
            fileContext.SaveChanges(adults,false);
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult adultToRemove = adults.First(a => a.id == adultId);
            adults.Remove(adultToRemove);
            fileContext.SaveChanges(adults,false);
        }

        public async Task Update(Adult adult)
        {
            int index = adults.IndexOf(adults.First(a => a.id == adult.id));
            adults[index] = adult;
            fileContext.SaveChanges(adults, false);
        }

        public async Task<Adult> GetAsync(int id)
        {
            return adults.First(a => a.id == id);
        }
    }
}