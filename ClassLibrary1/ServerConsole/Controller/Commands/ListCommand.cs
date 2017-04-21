using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
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
        /// Constructor.
        /// </summary>
        /// <param name="m">
        /// The model </param>
        public ListCommand(IModel m)
        {
            this.model = m;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            List<string> games = this.model.AvaliableGames();
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
