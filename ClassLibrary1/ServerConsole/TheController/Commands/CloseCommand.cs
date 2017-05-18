
namespace ServerConsole.TheController.Commands
{
    using System.Net.Sockets;
    using TheModel;

    /// <summary>
    /// A class for the command that closes the connection.
    /// </summary>
    public class CloseCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloseCommand"/> class. 
        /// </summary>
        /// <param name="m">
        /// Is the model 
        /// </param>
        public CloseCommand(IModel m)
        {
            this.model = m;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns>The respond of the execution</returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            return model.CloseGame(name, client);
        }

        /// <summary>
        /// Getter that tells if the command is not single player command.
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        public bool GetIsSingle()
        {
            return false;
        }
    }
}
