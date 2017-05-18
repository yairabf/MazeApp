using System;
using System.IO;
using System.Net.Sockets;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ServerConsole.TheModel
{
    /// <summary>
    /// A class that controls a game of two players.
    /// </summary>
    class Game
    {
        /// <summary>
        /// The name of the game.
        /// </summary>
        private string name;
        /// <summary>
        /// The maze of the game.
        /// </summary>
        private Maze maze;
        /// <summary>
        /// first player participating in the game.
        /// </summary>
        private Player playerOne;
        /// <summary>
        /// first player participating in the game.
        /// </summary>
        private Player playerTwo;
        /// <summary>
        /// Boolean, determines of the game is occupied or not.
        /// </summary>
        private bool occupied;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="m"> Is the maze </param>
        /// <param name="pOne"> The first player </param>
        public Game(Maze m, Player pOne)
        {
            this.name = m.Name;
            this.maze = m;
            this.playerOne = pOne;
            this.playerOne.SetPosition(maze.InitialPos);
            this.occupied = false;
        }

        /// <summary>
        /// Sets the second player once join is sent by a different client.
        /// </summary>
        /// <param name="pTwo">
        /// The second player </param>
        public void SetPlayerTwo(Player pTwo)
        {
            this.playerTwo = pTwo;
            this.playerTwo.SetPosition(maze.InitialPos);
        }

        /// <summary>
        /// Converts the game to json.
        /// </summary>
        /// <returns>
        /// A jason string </returns>
        public string ToJSON()
        {
            return maze.ToJSON();
        }

        /// <summary>
        /// Sends the message that a game has started to both players, as a jason.
        /// </summary>
        /// <returns>
        /// A jason string </returns>
        public string SendStartingMessages()
        {
            if (playerOne != null && playerTwo != null)
            {
                TcpClient clientOne = playerOne.GetTcpClient();
                Console.WriteLine("starting game: " + name);
                NetworkStream stream = clientOne.GetStream();
                    //using (StreamReader reader = new StreamReader(stream))
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(maze.ToJSON());
                writer.Flush();
                return maze.ToJSON();
            }
            return string.Empty;
        }

        /// <summary>
        /// Setter. Sets the players positions. 
        /// </summary>
        /// <param name="p1"> Player one </param>
        /// <param name="p2">Player two </param>
        public void SetPositions(Position p1, Position p2)
        {
            this.playerOne.SetPosition(p1);
            this.playerTwo.SetPosition(p2);
        }

        /// <summary>
        /// Moves a player.
        /// </summary>
        /// <param name="movement"> Wehre to move to </param>
        /// <param name="tcpClient"> The client we are talking to </param>
        /// <returns></returns>
        public string MovePlayer(string movement, TcpClient tcpClient)
        {
            Player player1 = null;
            Player player2 = null;;
            //checking which client sent us the play movement
            if (tcpClient == playerOne.GetTcpClient())
            {
                Console.WriteLine("this is player one");
                player1 = playerOne;
                player2 = playerTwo;
            }
            else if(tcpClient == playerTwo.GetTcpClient())
            {
                Console.WriteLine("this is player two");
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
            BinaryWriter clientStream = new BinaryWriter(player2.GetTcpClient().GetStream());
            clientStream.Write(message);
            clientStream.Flush();
            return "notified";
        }

        /// <summary>
        /// checks which player has requested to move and updates the position up if possible
        /// </summary>
        /// <param name="player"> The player that needs to move </param>
        private void MovePlayerUp(Player player)
        {
            if ((player.GetPosition().Row - 1) >= 0 &&
                maze[player.GetPosition().Row - 1, player.GetPosition().Col] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row - 1, player.GetPosition().Col));
            }
        }

        /// <summary>
        /// checks which player has requested to move and updates the position left if possible
        /// </summary>
        /// <param name="player"> The player that needs to move </param>
        private void MovePlayerLeft(Player player)
        {
            if ((player.GetPosition().Col - 1) >= 0 &&
                maze[player.GetPosition().Row, player.GetPosition().Col - 1] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row, player.GetPosition().Col - 1));
            }
        }

        /// <summary>
        /// checks which player has requested to move and updates the position right if possible
        /// </summary>
        /// <param name="player"> The player that needs to move </param>
        private void MovePlayerRight(Player player)
        {
            if ((player.GetPosition().Col + 1) < maze.Cols &&
                maze[player.GetPosition().Row, player.GetPosition().Col + 1] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row, player.GetPosition().Col + 1));
            }
        }

        /// <summary>
        /// checks which player has requested to move and updates the position down if possible
        /// </summary>
        /// <param name="player"> The player that needs to move </param>
        private void MovePlayerDown(Player player)
        {
            if ((player.GetPosition().Row + 1) < maze.Rows &&
                maze[player.GetPosition().Row + 1, player.GetPosition().Col] != CellType.Wall)
            {
                player.SetPosition(new Position(player.GetPosition().Row + 1, player.GetPosition().Col));
            }
        }

        /// <summary>
        /// creates the message for the second object
        /// </summary>
        /// <param name="movement"> Where the player has moved to </param>
        /// <returns>
        /// A string of the message </returns>
        private string PlayMessage(string movement)
        {
            JObject message = new JObject();
            message["Name"] = this.name;
            message["Direction"] = movement;
            return message.ToString();
        }

        /// <summary>
        /// The messages sent when needs to close connection.
        /// Sends to one client, and returns the message till the ch sends it.
        /// </summary>
        /// <param name="tcpClient"> The client we are talking to </param>
        /// <returns>
        /// Thr messgae to be sent </returns>
        public string CloseMessage(TcpClient tcpClient)
        {
            Player secondPlayer = null;
            if (tcpClient == this.playerOne.GetTcpClient())
                secondPlayer = this.playerTwo;
            else
                secondPlayer = this.playerOne;

            string message = "The " + this.name + " game been closed.";
            BinaryWriter clientStream = new BinaryWriter(secondPlayer.GetTcpClient().GetStream());
            clientStream.Write(message);
            secondPlayer.GetTcpClient().Close();
            clientStream.Flush();
            return message;
        }


        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The name </returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Returns true if the game is occuppied otherwise false.
        /// </summary>
        /// <returns>
        /// Boolean accordingly </returns>
        public bool IsOccuiped()
        {
            return this.occupied;
        }

        /// <summary>
        /// Setter.
        /// </summary>
        /// <param name="occ"> If occupied or not </param>
        public void SetOccuiped(bool occ)
        {
            this.occupied = occ;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The first player </returns>
        public Player GetPlayerOne()
        {
            return this.playerOne;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// The second player </returns>
        public Player GetPlayerTwo()
        {
            return this.playerTwo;
        }
    }
}
