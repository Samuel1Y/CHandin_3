using System.Collections;
using System.Collections.Generic;
using System.IO;
using FileData;
using Models;

namespace WebApplication.Data.Impl.Adults
{
    public class AdultsData : IAdults
    {
        private IList<Adult> adults;

        public AdultsData()
        {
            FileContext fileContext = new FileContext();
            adults = fileContext.Adults;
        }
        public IList<Adult> GetAdults()
        {
            List<Adult> list = new List<Adult>(adults);
            return list;
        }

        public void AddAdult(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAdult(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Adult adult)
        {
            throw new System.NotImplementedException();
        }

        public Adult Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}