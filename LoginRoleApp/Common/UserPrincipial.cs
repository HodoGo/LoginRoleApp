using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LoginRoleApp.Common
{
    public class UserPrincipial : IPrincipal
    {
        private UserIdentity _userIdentity;
        public UserIdentity UserIdentity
        {
            get { return _userIdentity; }
            set { _userIdentity = value; }
        }
        IIdentity IPrincipal.Identity
        {
            get { return UserIdentity; }
        }
        public bool IsInRole(string role)
        {
            if (_userIdentity != null)
                return _userIdentity.Role.Equals(role);
            else
                return false;
        }
    }
}
