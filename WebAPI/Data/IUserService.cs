using WebApplication.Models;

namespace WebApplication.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}