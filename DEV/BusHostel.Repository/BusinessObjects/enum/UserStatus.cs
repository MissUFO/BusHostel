using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.Repository.BusinessObjects
{
    /// <summary>
    /// User status
    /// </summary>
    public enum UserStatus : byte
    {
        Locked = 0,
        Active = 1
    }
}
