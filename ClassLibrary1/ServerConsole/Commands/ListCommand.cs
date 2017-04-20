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
            string stringList = "[\n";
            foreach (var game in games)
            {
                stringList += " " + game + '\n';
            }
            stringList += "]";
            return stringList;
        }

        public bool GetIsSingle()
        {
            return true;
        }
    }
}
