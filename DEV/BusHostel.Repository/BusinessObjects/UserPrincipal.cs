using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.Repository.BusinessObjects
{
    /// <summary>
    /// Implemented from the interface IIdentity. Provides the Principal properties for the user connected to the system.
    /// </summary>
    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }
        IIdentity identity;

        public int UserID
        {
            get
            {
                if (userID == 0)
                {
                    UserIdentity _identity = Identity as UserIdentity;
                    if (_identity != null && _identity.User != null)
                        userID = _identity.User.ID;
                }

                return userID;
            }
            set { userID = value; }
        }
        private int userID = 0;

        public string Login
        {
            get
            {
                if (login == string.Empty)
                {
                    UserIdentity _identity = Identity as UserIdentity;
                    if (_identity != null && _identity.User != null)
                        login = _identity.User.Login;
                }

                return login;
            }
            set { login = value; }
        }
        private string login = string.Empty;


        public bool IsInRole(RoleType role)
        {
            UserIdentity _identity = Identity as UserIdentity;
            if (_identity != null && _identity.User != null && _identity.User.Role.Count(itm => itm.RoleTypeID == role) > 0)
                return true;
            else
                return false;
        }

        public UserPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            return IsInRole((RoleType)Enum.Parse(typeof(RoleType), role));
        }
    }
}
