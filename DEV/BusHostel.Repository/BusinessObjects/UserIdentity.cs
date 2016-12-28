using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.Repository.BusinessObjects
{
    /// <summary>
    /// Implemented from the interface IIdentity. Provides the Identity for the user connected to the system.
    /// </summary>
    public class UserIdentity : IIdentity
    {
        public User User
        {
            get { return _User; }
            private set { _User = value; }
        }
        private User _User;

        public string AuthenticationType
        {
            get { return "Form Authentication"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _User == null ? null : _User.Name; }
        }

        public UserIdentity(User userLogin)
        {
            _User = userLogin;
        }

        public UserIdentity()
        { }

    }
}