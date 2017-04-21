


using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
    /// <summary>
    /// A class for the client side of the connection.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The t cancellation
        /// </summary>
        private static CancellationTokenSource taskCancellation;

        /// <summary>
        /// The stream
        /// </summary>
        private static NetworkStream stream;

        /// <summary>
        /// The writer
        /// </summary>
        private static BinaryWriter writer;

        /// <summary>
        /// The end point
        /// </summary>
        private static IPEndPoint endPoint;

        /// <summary>
        /// The TCP client
        /// </summary>
        private TcpClient tcpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class. 
        /// initialize the tcp client
        /// </summary>
        public Client()
        {
            tcpClient = new TcpClient();
        }

        /// <summary>
        /// The first function the gets called by the program, starts the process
        /// and writes to the server.
        /// </summary>
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

                try
                {
                    writer.Write(command);
                    writer.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Connects the client to the server and creates a reading thread.
        /// </summary>
        public void Connect()
        {
            try
            {
                int port = int.Parse(ConfigurationManager.AppSettings["PortNum"]);
                endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                tcpClient.Connect(endPoint);
                Console.WriteLine("You are connected");
                stream = tcpClient.GetStream();
                writer = new BinaryWriter(stream);
                ReadingTasks();
            }
            catch (Exception e)
            {
                Console.WriteLine("not Connected");
            }
        }

        /// <summary>
        /// A private method for reading from the server.
        /// </summary>
        private void ReadingTasks()
        {
            Task listening = new Task(() =>
            {
                BinaryReader reader = new BinaryReader(tcpClient.GetStream());
                {
                    while (tcpClient.Connected)
                    {
                        try
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
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            });
            listening.Start();
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        private void CloseConnection()
        {
            tcpClient.Close();
            tcpClient = new TcpClient();
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

                   
                }
            }

            tcpClient.Close();
        }

        private static void StartMultiPlayThread()
        {
            taskCancellation = new CancellationTokenSource();
            CancellationToken ctask = taskCancellation.Token;
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