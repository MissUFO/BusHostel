using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusHostel.Repository
{
    public class BookingRepository
    {
        public static bool IsBookingAvailable()
        {
            return true;
        }

        public static List<string> BookingsList()
        {
            return new List<string>();
        }
        
        public static List<string> EmptyRoomsList()
        {
            return new List<string>();
        }

        public static bool Add()
        {
            return true;
        }

        public static bool Edit()
        {
            return true;
        }

        public static bool Delete()
        {
            return true;
        }

        public static bool Decline()
        {
            return true;
        }
        
    }
}
