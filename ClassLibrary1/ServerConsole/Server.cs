namespace ServerConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The srver class.
    /// </summary>
    class Server
    {
        /// <summary>
        /// The port.
        /// </summary>
        private int port;

        /// <summary>
        /// Listener to new clients.
        /// </summary>
        private TcpListener listener;

        /// <summary>
        /// The client handler.
        /// </summary>
        private IClientHandler ch;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="port">The port.</param>
        /// <param name="ch">Th client handler.</param>
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

        /// <summary>
        /// Creates a thread for every incoming client and lets the client handler deal with him.
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), this.port);
            this.listener = new TcpListener(ep);
            this.listener.Start();
            Console.WriteLine("Waiting for connections...");
            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = this.listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        this.ch.HandleClient(client);
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }

                Console.WriteLine("Server stopped");
            });
            task.Start();
            task.Wait();
        }

        /// <summary>
        /// Tells the listener to stop.
        /// </summary>
        public void Stop()
        {
            this.listener.Stop();
        }
    }
}