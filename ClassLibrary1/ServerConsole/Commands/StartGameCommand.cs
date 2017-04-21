using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ServerConsole
{
    /// <summary>
    /// A class for the start command.
    /// </summary>
    class StartGameCommand : ICommand
    {
        /// <summary>
        /// The model. 
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"></param>
        public StartGameCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            return this.model.StartGame(name, rows, cols, client);
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        public bool GetIsSingle()
        {
            return false;
        }
    }
}
