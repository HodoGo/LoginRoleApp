using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Common
{
    public class UserIdentity : IIdentity
    {
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Role { get; set; }
        public UserIdentity(string login, string fio, string role)
        {
            Login = login;
            FIO = fio;
            Role = role;
        }
        public string AuthenticationType { get { return "User authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }

        public string Name => FIO;
    }
}
