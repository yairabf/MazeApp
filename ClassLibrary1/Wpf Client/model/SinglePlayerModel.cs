using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using ClientConsole;
using MazeLib;

namespace Wpf_Client.model 
{
    class SinglePlayerModel : GameModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Maze maze;

        private string solution;

        //private Client client;

        private string mazeName;

        private int rows;

        private int cols;
        //all privates from previous client*******8
        /// <summary>
        /// The t cancellation
        /// </summary>
        private static CancellationTokenSource taskCancellation;

        //public delegate void GetMessage(string message);
        //public event Client.GetMessage Notify;


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

        public SinglePlayerModel()
        {
            tcpClient = new TcpClient();
        }
        
        public void StartGame()
        {
            string generate = this.mazeName + " " + this.rows + " " + this.cols;
            client.SendCommands(generate);

        }
        public string SolveGame()
        {
            int algorithm = Wpf_Client.Properties.Settings.Default.SearchAlgorithm;
            string solve = "solve " + maze.Name + " " + algorithm;
            client.SendCommands(solve);
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void HandleStart(string mazeString)
        {
            clientNotify -= HandleStart;
            client.Notify += HandeSolve;
            this.maze = Maze.FromJSON(mazeString);
        }

        private void HandeSolve(string s)
        {
            this.solution = s;
        }

        public Maze mazeProp
        {
            get { return maze; }
            set
            {
                this.maze = value;
                OnPropertyChanged("maze");
            }
        }

        //properties of SP_MenuVm
        public int NumOfRows
        {
            get { return maze.Rows; }
            set { this.rows = value; }
        }

        public int NumOfCol
        {
            get { return maze.Cols; }
            set { this.cols = value; }
        }

        public string NameOfMaze
        {
            get { return maze.Name; }
            set { this.mazeName = value; }
        }

        /// <summary>
        /// The first function the gets called by the program, starts the process
        /// and writes to the server.
        /// </summary>
        public void SendCommands(string commend)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(100);
                Console.Write("Please enter a command: ");
                string command = commend;
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
            int port = Int32.Parse(ConfigurationManager.AppSettings["PortNum"]);
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            tcpClient.Connect(endPoint);
            Console.WriteLine("You are connected");
            stream = tcpClient.GetStream();
            //reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
            ReadingTasks();
            try
            {
                port = int.Parse(ConfigurationManager.AppSettings["PortNum"]);
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
                                this.Notify(feedback);
                                CloseConnection();
                            }
                            else
                            {
                                this.Notify(feedback);
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
    }
}
