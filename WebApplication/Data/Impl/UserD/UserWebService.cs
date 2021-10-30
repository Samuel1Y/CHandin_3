using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication.Data.Impl.Adults;
using WebApplication.Models;

namespace WebApplication.Data.Impl.UserD
{
    public class UserWebService: IUserService
    {
        public async Task<Models.User> ValidateLogin(string username, string password)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/users?username={username}&password={password}");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string userAsJson = await response.Content.ReadAsStringAsync();
                    User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                    return resultUser;
                } 
                throw new Exception("User not found");
            }
    }
}