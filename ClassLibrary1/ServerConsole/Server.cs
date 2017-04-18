﻿
namespace ServerConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    class Server
    {
       
        private int port;
        private TcpListener listener;
        private IClientHandler ch;

        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }

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

        public void Stop()
        {
            this.listener.Stop();
        }
    }
}
