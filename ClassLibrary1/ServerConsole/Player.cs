using System;
using System.Net.Sockets;
using MazeLib;

namespace ServerConsole
{
    /// <summary>
    /// A class for a player in the game.
    /// </summary>
    class Player
    {
        /// <summary>
        /// The connection info.
        /// </summary>
        private TcpClient tcpClient;
        /// <summary>
        /// The client Name.
        /// </summary>
        private string name;
        /// <summary>
        /// The position the player is at, in the maze.
        /// </summary>
        private Position currentPosition;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"> Players name </param>
        /// <param name="tcpClient"> The client connection info </param>
        public Player(string name, TcpClient tcpClient)
        {
            this.name = name;
            this.tcpClient = tcpClient;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The tcp client member</returns>
        public TcpClient GetTcpClient()
        {
            return tcpClient;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The players position </returns>
        public Position GetPosition()
        {
            return this.currentPosition;
        }

        /// <summary>
        /// Setter.
        /// </summary>
        /// <param name="p"> The new position </param>
        public void SetPosition(Position p)
        {
            this.currentPosition = p;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The name of the client</returns>
        public String GetName()
        {
            return name;
        }
    }
}
