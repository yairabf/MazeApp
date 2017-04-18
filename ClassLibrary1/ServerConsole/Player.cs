using System;
using System.Net.Sockets;
using MazeLib;

namespace ServerConsole
{
    class Player
    {
        private TcpClient tcpClient;
        private string name;
        private Position currentPosition;

        public Player(string name, TcpClient tcpClient)
        {
            this.name = name;
            this.tcpClient = tcpClient;
        }

        public TcpClient GetTcpClient()
        {
            return tcpClient;
        }

        public Position GetPosition()
        {
            return this.currentPosition;
        }

        public void SetPosition(Position p)
        {
            this.currentPosition = p;
        }

        public String GetName()
        {
            return name;
        }
    }
}
