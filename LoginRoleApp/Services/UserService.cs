using LoginRoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Services
{
    public class UserService
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                  Login = "admin1",
                  Password = "admin",
                  FIO = "Adminov Admin",
                  Role = Role.Admin

                },
                new User()
                {
                    Login = "user",
                    Password = "user",
                    FIO = "Testov Test",
                    Role = Role.User
                },
            };
        }
    }
}
