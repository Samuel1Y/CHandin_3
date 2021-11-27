using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data.Impl.Users
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string passWord);
    }
}