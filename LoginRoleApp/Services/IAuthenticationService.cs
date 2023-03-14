using LoginRoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Services
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}
