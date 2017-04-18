
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
    using MazeLib;

    class Client
    {
        private bool connected;

        public Client()
        {
            connected = true;
        }

        public void StartConnection()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3501);
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            Console.WriteLine("You are connected");

            /* using (NetworkStream stream = tcpClient.GetStream())
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
             }*/
            using (NetworkStream stream = tcpClient.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                while (this.connected)
                {
                    // Sending a command to server
                    Console.Write("Please enter a command: ");
                    string command = Console.ReadLine();
                    writer.WriteLine(command);
                    writer.Flush();
                    Console.WriteLine("{0}", command);

                    // reading a reply from server
                    while (true)
                    {
                        string feedback = reader.ReadLine();
                        if (reader.Peek() == '@')
                        {
                            feedback.TrimEnd('\n');
                            break;
                        }

                        Console.WriteLine("{0}", feedback);
                    }

                    if (command.Equals("close"))
                    {
                        this.connected = false;
                    }
                    //reader.ReadLine();

                    // ************TODO - ADD a condition of receiving empty jason obj to stop loop*****
                }
            }

            tcpClient.Close();
        }
    }
}
