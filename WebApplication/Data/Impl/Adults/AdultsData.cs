using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IList<Adult> GetAdults()
        {
            List<Adult> list = new List<Adult>(adults);
            return list;
        }

        public void AddAdult(Adult adult)
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

        public Adult Get(int id)
        {
            return adults.First(a => a.Id == id);
        }
    }
}