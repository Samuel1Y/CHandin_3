using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebApplication.Data.Impl.Adults
{
    public interface IAdults
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<Adult>   AddAdultAsync(Adult adult);
        Task   RemoveAdultAsync(int Id);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}