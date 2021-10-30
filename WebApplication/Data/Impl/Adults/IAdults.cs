using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApplication.Data.Impl.Adults
{
    public interface IAdults
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task Update(Adult adult);
        Task<Adult> GetAsync(int id);
    }
}