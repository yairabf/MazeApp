using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IController controller = new Controller();
            IModel model = new Model();
            //controller.SetModel(model);
            IClientHandler viewHandler = new ClientHandler(controller);
            controller.SetView(viewHandler);
            Server server = new Server(3501, viewHandler);
            server.Start();
        }
    }
}
