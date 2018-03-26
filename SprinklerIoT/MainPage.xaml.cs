using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Gpio;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Connectivity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SprinklerIoT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Our pin values
        private static readonly int[] RELAY_PIN = new int[] { 2, 3, 4, 5 };

        // Initialization pin
        private GpioPin pin;

        // Physical Relay Pins
        private GpioPin pin1;
        private GpioPin pin2;
        private GpioPin pin3;
        private GpioPin pin4;
        private GpioPinValue pinValue;
        
        private DispatcherTimer timer;
        private SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        private SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.LightGray);
        
        

        

        public MainPage()
        {
            InitializeComponent();

            
            InitGPIO();
            getDate();


        }

        private void InitGPIO()
        {
            // Initialization Gpio Controller
            var gpio = GpioController.GetDefault();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                pin1 = pin2 = pin3 = pin4 = null;
              
                return;
            }


            pinValue = GpioPinValue.High;

            // Initialize all the pins
            for (int i = 0; i < RELAY_PIN.Length; i++)
            {
                pin = gpio.OpenPin(RELAY_PIN[i]);
                pin.Write(pinValue);
                pin.SetDriveMode(GpioPinDriveMode.Output);
            }
            

        }
        /// <summary>
        /// Get the current date
        /// </summary>
        private void getDate()
        {
            DateTime dateTime = DateTime.Today;
            date.Text = dateTime.ToString("d");
        }
        
        /// <summary>
        /// class for toggling the pin
        /// </summary>
        /// <param name="pin">GPIO pin number</param>
        /// <param name="s">Reference to button control/object with raised event</param>
        private void togglePin(GpioPin pin, object s)
        {
            // Initialize the components
            Button btn = s as Button;
            var pinValue = pin.Read();

            // Toggle the relay and update the button background colour
            if (pinValue == GpioPinValue.High)
            {
                pinValue = GpioPinValue.Low;
                pin.Write(pinValue);
                btn.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                btn.Content = "Relay ON";
            }
            else
            {
                pinValue = GpioPinValue.High;
                pin.Write(pinValue);
                btn.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                btn.Content = "Relay OFF";
            }
        }

        /// <summary>
        /// Toggle button for relay 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sButton1_Click(object sender, RoutedEventArgs e)
        {
            togglePin(pin1, sender);
            
        }

        /// <summary>
        /// Toggle button for relay 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sButton2_Click(object sender, RoutedEventArgs e)
        {
            togglePin(pin2, sender);
        }

        /// <summary>
        /// Toggle button for relay 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sButton3_Click(object sender, RoutedEventArgs e)
        {
            togglePin(pin3, sender);
        }

        /// <summary>
        /// Toggle button for relay 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sButton4_Click(object sender, RoutedEventArgs e)
        {
            togglePin(pin4, sender);
        }

        
    }
}
