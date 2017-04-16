using System.Net.Sockets;

namespace ServerConsole
{
    class Player
    {
        private TcpClient tcpClient;
        private string name;

        public Player(string name, TcpClient tcpClient)
        {
            this.name = name;
            this.tcpClient = tcpClient;
        }
    }
}
