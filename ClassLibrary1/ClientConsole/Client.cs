
using System.Threading;

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
        private TcpClient tcpClient;
        private static CancellationTokenSource tCancellation;
        private static NetworkStream stream;
        private static BinaryReader reader;
        private static BinaryWriter writer;
        private static IPEndPoint endPoint;

        public Client()
        {
            connected = true;
        }

        public void StartConnection()
        {
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3501);
            tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            Console.WriteLine("You are connected");
            using (stream = tcpClient.GetStream())
            using (reader = new BinaryReader(stream))
            using (writer = new BinaryWriter(stream))
            {
                while (this.connected)
                {
                    // Sending a command to server
                    Console.Write("Please enter a command: ");
                    string command = Console.ReadLine();
                    writer.Write(command);
                    writer.Flush();
                    Console.WriteLine("{0}", command);
                    if (command.Contains("start") || command.Contains("join"))
                    {
                        StartMultiPlayThread();
                    }
                    // reading a reply from server
                    string feedback = reader.ReadString();
                    Console.WriteLine("{0}", feedback);
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

        private static void StartMultiPlayThread()
        {
            tCancellation = new CancellationTokenSource();
            CancellationToken ctask = tCancellation.Token;
            Task multi = new Task(() =>
            {
                bool playing = true;
                {
                    while (playing)
                    {
                        string feedback = reader.ReadString();
                        if (feedback.Contains("closed"))
                            playing = false;
                        Console.WriteLine(feedback);
                        writer.Write("notified");
                    }
                }
            }, ctask);
            multi.Start();
        }
    }
}
