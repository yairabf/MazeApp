

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
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                    {
                        while (client.Connected)
                        {
                            try
                            {
                                string commandLine = reader.ReadString();
                                if (commandLine.Contains("notified"))
                                    continue;
                                Console.WriteLine("Got command: {0}", commandLine);

                                string result = controller.ExecuteCommand(commandLine, client);
                                //if(result.Contains("notified"))
                                //  continue;
                                Console.WriteLine(result);
                                Console.WriteLine(commandLine);
                                result += '\n';
                                writer.Write(result);
                                writer.Flush();
                                if (result.Contains("closed"))
                                {
                                    Console.WriteLine("closing client");
                                    //writer.Write(result);
                                    client.Close();
                                    break;
                                }

                                if (controller.CloseSingle(commandLine, client))
                                {
                                    writer.Write("null");
                                    client.Close();
                                    break;
                                }   
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine("entered catch");
                                //Console.WriteLine(e);
                            }     
                        }
                    }
                    //client.Close();
                }).Start();
        }
    }

}
