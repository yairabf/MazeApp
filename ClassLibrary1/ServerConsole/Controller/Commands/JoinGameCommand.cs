using System;
using System.Net.Sockets;

namespace ServerConsole.Controller.Commands
{
    /// <summary>
    /// A class for the join command.
    /// </summary>
    public class JoinGameCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinGameCommand"/> class. 
        /// </summary>
        /// <param name="model">
        /// The model 
        /// </param>
        public JoinGameCommand(IModel model)
        {
            this.model = model;
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
            return this.model.JoinGame(name, client);
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
