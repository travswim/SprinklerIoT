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

        // Get/Set the name of the sprinkler
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        // Get/Set the location of the sprinkler
        public string Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        // Get/Set the pin of the sprinkler
        public GpioPin pinVal
        {
            get { return this.pin; }
            set { this.pin = value; }
        }

        // Get/Set the Duration of the sprinkler on time
        public TimeSpan Durration
        {
            get { return this.durration; }
            set { this.durration = value; }
        }

        // Get/Set the start time of the sprinkler
        public DateTime StartWater
        {
            get { return this.waterStart; }
            set { this.waterStart = value; }
        }
        
        

        // Turn on the sprinkler
        private void turnON()
        {
            pin.Write(GpioPinValue.High);
            // Can do other stuff later ex: graphics, send to Azure, SQL database etc
        }

        // Turn off the sprinkler
        private void turnOFF()
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

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December

    }
    public enum Location
    {
        North = 1,
        South,
        East,
        West
    }

    public class Restrictions
    {
        List<DateTime> allowedDays = new List<DateTime>();

    }
    
}
