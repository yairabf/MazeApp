
namespace ServerConsole
{
    using System;
    using System.Configuration;
    using TheController;
    using View;
    

    /// <summary>
    /// The program class for the server.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            IController controller = new Controller();
            IClientHandler viewHandler = new ClientHandler(controller);
            controller.SetView(viewHandler);
            int port = int.Parse(ConfigurationManager.AppSettings["PortNum"]);
            //int port = 55;
            Console.WriteLine("Connecting to server at 127.0.0.1:{0}", port);
            Server server = new Server(port, viewHandler);
            server.Start();
        }
    }
}
