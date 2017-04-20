using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ServerConsole
{
    class StartGameCommand : ICommand
    {
        private IModel model;

        public StartGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            return this.model.StartGame(name, rows, cols, client);
        }

        public bool GetIsSingle()
        {
            return false;
        }
    }
}
