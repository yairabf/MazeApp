using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
    class Game
    {
        private string name;
        private Maze maze;
        private Player playerOne;
        private Player playerTwo;
        private bool occupied;

        public Game(Maze m, Player pOne)
        {
            this.name = m.Name;
            this.maze = m;
            this.playerOne = pOne;
            this.playerOne.SetPosition(maze.InitialPos);
            this.occupied = false;
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

        public string MovePlayer(string movement, TcpClient tcpClient)
        {
            Player player1 = null;
            Player player2 = null;;
            //checking which client sent us the play movement
            if (tcpClient == playerOne.GetTcpClient())
            {
                player1 = playerOne;
                player2 = playerTwo;
            }
            else if(tcpClient == playerTwo.GetTcpClient())
            {
                player1 = playerTwo;
                player2 = playerOne;
            }
            else
            {
                Console.WriteLine("Error: can not compare between tcp clients in MovePlayer in model");
            }
            switch (movement)
            {
                case "up":
                    MovePlayerUp(player1);
                    break;
                case "left":
                    MovePlayerLeft(player1);
                    break;
                case "right":
                    MovePlayerRight(player1);
                    break;
                case "down":
                    MovePlayerDown(player1);
                    break;
                default:
                    return "incorrect movement";
            }
            //sending a message to the other player
            string message = PlayMessage(movement);
            StreamWriter clientStream = new StreamWriter(player2.GetTcpClient().GetStream());
            clientStream.Write(message);
            return "";
        }

        //checks which player has requested to move and updates the position up if possible
        private void MovePlayerUp(Player player)
        {
            if ((player.GetPosition().Row - 1) >= 0 &&
                maze[player.GetPosition().Row - 1, player.GetPosition().Col] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row - 1, player.GetPosition().Col));
            }
        }

        private void MovePlayerLeft(Player player)
        {
            if ((player.GetPosition().Col - 1) >= 0 &&
                maze[player.GetPosition().Row, player.GetPosition().Col - 1] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row, player.GetPosition().Col - 1));
            }
        }

        private void MovePlayerRight(Player player)
        {
            if ((player.GetPosition().Col + 1) < maze.Cols &&
                maze[player.GetPosition().Row, player.GetPosition().Col + 1] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row, player.GetPosition().Col + 1));
            }
        }

        private void MovePlayerDown(Player player)
        {
            if ((player.GetPosition().Row + 1) < maze.Rows &&
                maze[player.GetPosition().Row + 1, player.GetPosition().Col] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row + 1, player.GetPosition().Col));
            }
        }

        //creates the message for the second object
        private string PlayMessage(string movement)
        {
            JObject message = new JObject();
            message["Name"] = this.name;
            message["Direction"] = PlayMessage(movement);
            return message.ToString();
        }

        public string CloseMessage(TcpClient tcpClient)
        {
            Player secondPlayer = null;
            if (tcpClient.Equals(this.playerOne.GetTcpClient()))
                secondPlayer = this.playerTwo;
            else
                secondPlayer = this.playerOne;

            string message = "The " + this.name + " game been closed.";
            StreamWriter clientStream = new StreamWriter(secondPlayer.GetTcpClient().GetStream());
            clientStream.Write(message);
            return message;
        }



        public string GetName()
        {
            return this.name;
        }

        public bool IsOccuiped()
        {
            return this.occupied;
        }

        public Player GetPlayerOne()
        {
            return this.playerOne;
        }

        public Player GetPlayerTwo()
        {
            return this.playerTwo;
        }
    }
}
