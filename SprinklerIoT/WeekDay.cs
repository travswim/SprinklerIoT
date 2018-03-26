using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
namespace SprinklerIoT
{
    /// <summary>
    /// Sprinkler class for turning sprinkler on/off
    /// </summary>
    public class Sprinkler
    {
        private string name;
        private string location;
        private GpioPin pin;
        private TimeSpan durration;
        private DateTime waterStart;
        // int moistureLevel;   // Water soil moisture level
        // int lightIntensity;  // Light intensity sensor


        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }
        
        // pin get/set/initialization etc...

        // Turn on the sprinkler
        private void turnON(GpioPin pin)
        {
            pin.Write(GpioPinValue.High);
            // Can do other stuff later ex: graphics, send to Azure, sQL database etc
        }

        // Turn off the sprinkler
        private void turnOFF(GpioPin pin)
        {
            pin.Write(GpioPinValue.Low);
        }

    }

    /// <summary>
    /// Weekday
    /// </summary>
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
