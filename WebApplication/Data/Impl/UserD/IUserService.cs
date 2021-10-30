using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data.Impl.Adults
{
    public interface IUserService
    {
        Task<User> ValidateLogin(string username, string password);
    }
}