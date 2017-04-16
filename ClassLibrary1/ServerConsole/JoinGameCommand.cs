using System;
using System.Net.Sockets;

namespace ServerConsole
{
    class JoinGameCommand : ICommand
    {
        public string Execute(string[] args, TcpClient client = null)
        {
            throw new NotImplementedException();
        }
    }
}
