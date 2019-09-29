using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace device_to_iothub_demo
{
    class Program
    {

        private static DeviceClient s_deviceClient;

        // The device connection string to authenticate the device with your IoT hub.
        // Using the Azure CLI:
        // az iot hub device-identity show-connection-string --hub-name {YourIoTHubName} --device-id MyDotnetDevice --output table
        private static string s_connectionString = "{your device connection string}";

        private static int sendInterval = 1;


        static void Main(string[] args)
        {
            Console.WriteLine("This is a .net core device simulator in docker or vs/vscode.\nThe app need 2 parameters:\nthe first one is Iot device connection string, you can hard code set s_connectionString= you device connection string, \nthe second one is transmission interval(default is 1s)  .\n Ctrl-C to exit.\n");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("\nArgs_Param" + i.ToString() + ":" + args[i]);
            }

            if (args.Length<=1)
            {
                Console.WriteLine("Parameters are not passed in agrs.\n");

            }
            else
            {
                s_connectionString = args[0];
                sendInterval=  args.Length != 0 ? Convert.ToInt32(args[1]) : 1;
            }


           

            // Connect to the IoT hub using the MQTT protocol
            s_deviceClient = DeviceClient.CreateFromConnectionString(s_connectionString, TransportType.Mqtt);
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }


       

        // Async method to send simulated telemetry
        private static async void SendDeviceToCloudMessagesAsync()
        {
            // Initial telemetry values
            double minTemperature = 20;
            double minHumidity = 60;
            Random rand = new Random();

            while (true)
            {
                double currentTemperature = minTemperature + rand.NextDouble() * 15;
                double currentHumidity = minHumidity + rand.NextDouble() * 20;

                // Create JSON message
                var telemetryDataPoint = new
                {
                    temperature = currentTemperature.ToString("f2"),
                    humidity = currentHumidity.ToString("f2")
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                // Add a custom application property to the message.
                // An IoT hub can filter on these properties without access to the message body.
                message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");

                // Send the telemetry message
                await s_deviceClient.SendEventAsync(message);
                Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

                await Task.Delay(1000* sendInterval);
            }
        }
    }
}
