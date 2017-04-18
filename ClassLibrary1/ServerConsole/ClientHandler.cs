﻿
namespace ServerConsole
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    class ClientHandler : IClientHandler
    {
        private IController controller;

        public ClientHandler(IController controller)
        {
            this.controller = controller;
        }

        public void HandleClient(TcpClient client)
        {
            new Task(() =>
                {
                    using (NetworkStream stream = client.GetStream())
                    using (StreamReader reader = new StreamReader(stream))
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        while (true)
                        {
                            string commandLine = reader.ReadLine();
                            Console.WriteLine("Got command: {0}", commandLine);

                            string result = controller.ExecuteCommand(commandLine, client);
                            Console.WriteLine(result);
                            result += '\n';
                            result += '@';

                            writer.Write(result);
                            writer.Flush();
                        }
                    }
                    client.Close();
                }).Start();
        }
    }
}
