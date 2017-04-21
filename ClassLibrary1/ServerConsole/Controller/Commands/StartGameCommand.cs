

namespace ServerConsole.Controller.Commands
{
 
    using System.Net.Sockets;

    /// <summary>
    /// A class for the start command.
    /// </summary>
    public class StartGameCommand : ICommand
    {
        /// <summary>
        /// The model. 
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartGameCommand"/> class.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
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
