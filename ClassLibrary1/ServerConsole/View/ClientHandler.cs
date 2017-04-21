


namespace ServerConsole.View
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using ServerConsole.TheController;

    /// <summary>
    /// A class that handles a client from the server
    /// is actually the vies in MVC.
    /// </summary>
    public class ClientHandler : IClientHandler
    {
        /// <summary>
        /// The controller.
        /// </summary>
        private IController controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHandler"/> class. 
        /// </summary>
        /// <param name="controller">
        /// The controller 
        /// </param>
        public ClientHandler(IController controller)
        {
            this.controller = controller;
        }

        /// <summary>
        /// Handles the client. Receives the command and invokes
        /// the controller.
        /// </summary>
        /// <param name="client"> The client needed to be handled with </param>
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
                                Console.WriteLine(commandLine);
                                result += '\n';
                                writer.Write(result);
                                writer.Flush();
                                if (result.Contains("closed"))
                                {
                                    Console.WriteLine("closing client");
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
                                //Console.WriteLine("entered catch");
                                Console.WriteLine(e.Message);
                            }     
                        }
                    }
                }).Start();
        }
    }

}
