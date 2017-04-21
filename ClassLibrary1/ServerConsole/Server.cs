
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
        /// constructor.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ch"></param>
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

        /// <summary>
        /// Creates a threas for every incoming client and lets the ch deal with him.
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3501);
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
