
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
        //private bool connected;
        private TcpClient tcpClient;
        private static CancellationTokenSource tCancellation;
        private static NetworkStream stream;
        //private static BinaryReader reader;
        private static BinaryWriter writer;
        private static IPEndPoint endPoint;

        public Client()
        {
            tcpClient = new TcpClient();
            //connected = true;
        }

        public void Connect()
        {
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3501);
            tcpClient.Connect(endPoint);
            Console.WriteLine("You are connected");
            stream = tcpClient.GetStream();
            //reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            ReadingTasks();
        }

        private void ReadingTasks()
        {
            Task listening = new Task(() =>
            {
                BinaryReader reader = new BinaryReader(tcpClient.GetStream());
                //bool playing = true;
                {
                    while (tcpClient.Connected)
                    {
                        string feedback = reader.ReadString();
                        if (feedback == "null")
                        {
                            CloseConnection();
                        }
                        else if (feedback.Contains("closed"))
                        {
                            Console.WriteLine(feedback);
                            CloseConnection();
                        }
                        else
                        {
                            Console.WriteLine(feedback);
                        }
                        //writer.Write("notified");
                    }
                }
            });
            listening.Start();
            //listening.Wait();
        }
        
        private void CloseConnection()
        {
            tcpClient.Close();
            tcpClient = new TcpClient();
        }

        public void SendCommands()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write("Please enter a command: ");
                string command = Console.ReadLine();
                if (!this.tcpClient.Connected)
                {
                    Connect();
                }
                writer.Write(command);
                writer.Flush();
            }
         }







        /*
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
                        Console.WriteLine("starting start multiply thread function");
                        StartMultiPlayThread();
                        Console.WriteLine("finished the function multiply thread");
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
                        Console.WriteLine("writing feedback for client");
                        Console.WriteLine(feedback);
                        Console.WriteLine("finished writing feedback");
                        writer.Write("notified");
                    }
                }
            }, ctask);
            multi.Start();
            multi.Wait();
        }*/
    }
}
