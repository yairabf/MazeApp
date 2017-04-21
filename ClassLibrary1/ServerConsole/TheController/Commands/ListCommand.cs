
namespace ServerConsole.TheController.Commands
{
    using System.Collections.Generic;
    using System.Net.Sockets;
    using TheModel;

    /// <summary>
    /// A class for the list command.
    /// </summary>
    class ListCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListCommand"/> class. 
        /// </summary>
        /// <param name="m">
        /// The model 
        /// </param>
        public ListCommand(IModel m)
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
            List<string> games = this.model.AvailableGames();
            string stringList = "[\n";
            foreach (var game in games)
            {
                stringList += " " + game + '\n';
            }
            stringList += "]";
            return stringList;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        public bool GetIsSingle()
        {
            return true;
        }
    }
}
