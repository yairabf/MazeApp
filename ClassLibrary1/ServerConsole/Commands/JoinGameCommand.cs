using System;
using System.Net.Sockets;

namespace ServerConsole
{
    /// <summary>
    /// A class for the koin command.
    /// </summary>
    class JoinGameCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> The model </param>
        public JoinGameCommand(IModel model)
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
