using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data.Impl
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string passWord);
    }
}