using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI
{
    /*
     *  some methods in dbContext, idk if it's the correct that way
     *  3 Adultsdotn files are for the db, maybe you will need to change path in dbContext
     *  Last thing to do is update controllers to call methods from db I guess ?
     *  pls delete this comment after reading :)
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            //AddUser();
            //AddAdult();
            CreateHostBuilder(args).Build().Run();
            
        }
        
        private static void AddUser()
        {
            User user = new User()
            {
                UserName = "user1",
                Password = "password1",
                Role = "Admin"
            };
            using (DBContext lb = new DBContext())
            {
                lb.Users.Add(user);
                lb.SaveChanges();
            }
        }
        
        private static void AddAdult()
        {
            Adult adult2 = new Adult()
            {
                FirstName = "Mona",
                LastName = "Paimon",
                HairColor = "Blue",
                EyeColor = "blue",
                Age = 25,
                Weight = 47,
                Height = 162,
                Sex = "F",
                JobTitle = {JobTitle = "Teacher", Salary = 98742}
            };
            using (DBContext lb = new DBContext())
            {
                lb.Adults.Add(adult2);
                lb.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}