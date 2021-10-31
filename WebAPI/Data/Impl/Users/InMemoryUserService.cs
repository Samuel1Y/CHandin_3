using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService() {
            users = new[] {
                new User {
                    UserName = "AdminExample",
                    Password = "123456",
                    Role = "Admin"
                }
            }.ToList();
        }


        public async Task<User> ValidateUser(string userName, string password) {
            User first = users.FirstOrDefault(user => user.UserName.ToLower().Equals(userName.ToLower()));
            if (first == null) {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password)) {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}