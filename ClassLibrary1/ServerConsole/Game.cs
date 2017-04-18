using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ServerConsole
{
    class Game
    {
        private string name;
        private Maze maze;
        private Player playerOne;
        private Player playerTwo;

        public Game(Maze m, Player pOne)
        {
            this.name = m.Name;
            this.maze = m;
            this.playerOne = pOne;
            this.playerOne.SetPosition(maze.InitialPos);
        }

        public void SetPlayerTwo(Player pTwo)
        {
            this.playerTwo = pTwo;
            this.playerTwo.SetPosition(maze.InitialPos);
        }

        public string ToJSON()
        {
            return maze.ToJSON();
        }

        public string SendStartingMessages()
        {
            if (playerOne != null && playerTwo != null)
            {
                TcpClient clientOne = playerOne.GetTcpClient();
                Console.WriteLine("starting game: " + name);
                using (NetworkStream stream = clientOne.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(maze.ToJSON());
                }
                return maze.ToJSON();
            }
            return string.Empty;
        }

        public void SetPositions(Position p1, Position p2)
        {
            this.playerOne.SetPosition(p1);
            this.playerTwo.SetPosition(p2);
        }

        //public void Play()

    }
}
