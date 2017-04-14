
namespace ConsoleApp3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    class Client
    {
        public void StartConnection()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            Console.WriteLine("You are connected");
            using (NetworkStream stream = tcpClient.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Send data to server
                Console.Write("Please enter a number: ");
                int num = int.Parse(Console.ReadLine());
                writer.Write(num);
                // Get result from server
                int result = reader.Read();
                Console.WriteLine("Result = {0}", result);
            }

            tcpClient.Close();
        }
    }
}
