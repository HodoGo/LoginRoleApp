using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public Role Role { get; set; }
    }
}
