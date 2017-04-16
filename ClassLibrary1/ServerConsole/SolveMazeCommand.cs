using System;
using System.Net.Sockets;

namespace ServerConsole
{
    class SolveMazeCommand : ICommand
    {
        public string Execute(string[] args, TcpClient client = null)
        {
            throw new NotImplementedException();
        }
    }
}
