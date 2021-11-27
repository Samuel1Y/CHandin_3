using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data.Impl.Users
{
    public class InMemoryUserService : IUserService
    {
        private DBContext ctx;

        public InMemoryUserService()
        {
            ctx = new DBContext();
        }


        public async Task<User> ValidateUser(string userName, string password) {
            User first = await ctx.Users.FirstOrDefaultAsync(user => user.UserName.ToLower().Equals(userName.ToLower()));
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