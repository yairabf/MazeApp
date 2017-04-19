

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
                    using (BinaryReader reader = new BinaryReader(stream))
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    {
                        while (true)
                        {
                            string commandLine = reader.ReadString();
                            if(commandLine.Contains("notified"))
                                continue;
                            Console.WriteLine("Got command: {0}", commandLine);

                            string result = controller.ExecuteCommand(commandLine, client);
                            if(result.Contains("notified"))
                                continue;
                            Console.WriteLine(result);
                            result += '\n';
                            writer.Write(result);
                            writer.Flush();
                        }
                    }
                    client.Close();
                }).Start();
        }
    }

}
