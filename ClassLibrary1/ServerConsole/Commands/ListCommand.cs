using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
    class ListCommand : ICommand
    {
        private IModel model;

        public ListCommand(IModel m)
        {
            this.model = m;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            List<string> games = this.model.AvaliableGames();
            JObject gameToJason = new JObject();
            foreach (var game in games)
            {
                gameToJason.Add(game);
            }
            return gameToJason.ToString();
        }
    }
}
