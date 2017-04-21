using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole.Controller.Commands
{
    /// <summary>
    /// A class for the play command.
    /// </summary>
    public class PlayCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayCommand"/> class. 
        /// </summary>
        /// <param name="model">
        /// The model 
        /// </param>
        public PlayCommand(IModel model)
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
            string movement = args[0];
            return this.model.PlayTurn(movement, client);
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
