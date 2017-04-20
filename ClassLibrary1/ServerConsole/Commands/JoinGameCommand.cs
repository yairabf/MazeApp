using System;
using System.Net.Sockets;

namespace ServerConsole
{
    class JoinGameCommand : ICommand
    {
        private IModel model;

        public JoinGameCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            return this.model.JoinGame(name, client);
        }

        public bool GetIsSingle()
        {
            return false;
        }
    }
}
