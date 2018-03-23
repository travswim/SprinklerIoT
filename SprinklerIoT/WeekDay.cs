using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprinklerIoT
{
    public class Sprinkler
    {
        string name;
        string location;
        TimeSpan durration;
        DateTime waterStart;

        
    }

    public enum WeekDay
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
    public class Restrictions
    {
        List<DateTime> allowedDays = new List<DateTime>();

    }
    
}
