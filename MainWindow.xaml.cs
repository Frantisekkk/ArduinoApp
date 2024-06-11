using System;
using System.IO.Ports;
using System.Windows;

namespace skuska_arduino_app
{
    public partial class MainWindow : Window
    {
        private SerialPort mySerialPort = new SerialPort("COM4");  // Change to your COM port

        public MainWindow()
        {
            InitializeComponent();
            SetUpSerialPort();
        }

        private void SetUpSerialPort()
        {
            try
            {
                mySerialPort.BaudRate = 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.DataReceived += DataReceivedHandler;

                // Attempt to open the serial port
                mySerialPort.Open();
                Console.WriteLine("Serial port opened successfully.");
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error opening serial port: " + ex.Message);
            } 
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = mySerialPort.ReadLine();
                Dispatcher.Invoke(() =>
                {
                    // Update UI elements here
                    // Assuming you have a TextBlock named dataTextBlock in your MainWindow.xaml
                    // Uncomment the next line if your UI is ready
                    dataTextBlock.Text = "Received data: " + data;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from serial port: " + ex.Message);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (mySerialPort != null && mySerialPort.IsOpen)
            {
                mySerialPort.Close();  // Close the serial port gracefully on application close
                Console.WriteLine("Serial port closed.");
            }
        }
    }
}
