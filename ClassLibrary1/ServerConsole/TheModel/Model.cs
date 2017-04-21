
namespace ServerConsole.TheModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Sockets;
    using ClassLibrary1;
    using ClassLibrary1.Maze;
    using MazeGeneratorLib;
    using MazeLib;

    /// <summary>
    /// The model part of the MVC.
    /// </summary>
    internal class Model : IModel
    {
        /// <summary>
        /// A dictionary. The keys are the names and values are the mazes.
        /// </summary>
        private Dictionary<string, Maze> mazes;
       
        /// <summary>
        /// A dictionary. The keys are maze names and valus are the solutions for the mazes using bfs.
        /// </summary>
        private Dictionary<string, ISolution<Position>> bfsMazes;
        
        /// <summary>
        /// A dictionary. The keys are maze names and valus are the solutions for the mazes using dfs.
        /// </summary>
        private Dictionary<string, ISolution<Position>> dfsMazes;
        
        /// <summary>
        /// A dictionary. The keys are the game names and values are the game themselves.
        /// </summary>
        private Dictionary<string, Game> gameDictionary;
        
        /// <summary>
        /// A dictionary. The keys are the clients connected and values are the games they are in.
        /// </summary>
        private Dictionary<TcpClient, Game> clientGameDictionary;


        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class. 
        /// </summary>
        public Model()
        {
            mazes = new Dictionary<string, Maze>();
            bfsMazes = new Dictionary<string, ISolution<Position>>();
            dfsMazes = new Dictionary<string, ISolution<Position>>();
            gameDictionary = new Dictionary<string, Game>();
            clientGameDictionary = new Dictionary<TcpClient, Game>();
            
        }

        /// <summary>
        /// Generates maze and store it under the specified name.
        /// </summary>
        /// <param name="name">The name of the generated maze.</param>
        /// <param name="rows">The number of rows that the maze has.</param>
        /// <param name="cols">The number of columns that the maze has.</param>
        /// <returns>new maze</returns> 
        public Maze Generate(string name, int rows, int cols)
        {
            Maze maze;
            if (this.mazes.TryGetValue(name, out maze))
            {
                return maze;
            }

            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            maze = mazeGenerator.Generate(rows, cols);
            maze.Name = name;
            this.mazes.Add(maze.Name, maze);
            return maze;
        }


        /// <summary>
        /// Solves the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="algorithm">The algorithm.</param>
        /// <returns>the wanted solution</returns>
        public ISolution<Position> Solve(string name, int algorithm)
        {
            // Console.WriteLine("in model function");
            ISolution<Position> solvedMaze;
            if (algorithm == 0)
            {
                // Console.WriteLine("in model function bfs solution");
                if (this.bfsMazes.TryGetValue(name, out solvedMaze))
                {
                    return solvedMaze;
                }
                Maze maze;
                if (this.mazes.TryGetValue(name, out maze))
                {
                    // Console.WriteLine("in model function mazes");
                    Bfs<Position> bfs = new Bfs<Position>();
                    MazeToSearchableAdapter adapter = new MazeToSearchableAdapter(maze);
                    ISolution<Position> bfsSolution = bfs.Search(adapter);
                    Console.WriteLine(bfsSolution.ToString());
                    return bfsSolution;
                }
            }
            else
            {
                if (this.dfsMazes.TryGetValue(name, out solvedMaze))
                {
                    return solvedMaze;
                }
                Maze maze;
                if (this.mazes.TryGetValue(name, out maze))
                {
                    Dfs<Position> dfs = new Dfs<Position>();
                    MazeToSearchableAdapter adapter = new MazeToSearchableAdapter(maze);
                    ISolution<Position> dfsSolution = dfs.Search(adapter);
                    return dfsSolution;
                }
            }

            return null;
        }

        /// <summary>
        /// Starts a Game and waits for the second player.
        /// </summary>
        /// <param name="gameName"> Name of the game </param>
        /// <param name="rows"> Amount of rows for the game</param>
        /// <param name="cols"> Amount of columns for the game </param>
        /// <param name="tcpClient"> The client we are talking to </param>
        /// <returns>
        /// Information for the client regarding the game </returns>
        public string StartGame(string gameName, int rows, int cols, TcpClient tcpClient)
        {
            Game game;
            if (gameDictionary.TryGetValue(gameName, out game))
            {
                return "game is occupied";
            }
            Maze maze = this.Generate(gameName, rows, cols);
            game = new Game(maze, new Player("playerOne", tcpClient));
            gameDictionary.Add(gameName, game);
            return "wait for second player";
        }

        /// <summary>
        /// Joins an existing game and sends messages to both clients.
        /// </summary>
        /// <param name="gameName"> The name of the game to join </param>
        /// <param name="tcpClient"> The client we are talking to </param>
        /// <returns>
        /// A jason string of the maze </returns>
        public string JoinGame(string gameName, TcpClient tcpClient)
        {       
            if (gameDictionary.TryGetValue(gameName, out Game game))
            {
                if (!game.IsOccuiped())
                {
                    game.SetPlayerTwo(new Player("PlayerTwo", tcpClient));
                    game.SetOccuiped(true);
                    clientGameDictionary.Add(game.GetPlayerOne().GetTcpClient(), game);
                    clientGameDictionary.Add(game.GetPlayerTwo().GetTcpClient(), game);
                    return game.SendStartingMessages();
                }
            }
            return "Game does not exist or occupied";
        }

        /// <summary>
        /// Plays a Turn for a certain player.
        /// </summary>
        /// <param name="movement"> Where to move the player </param>
        /// <param name="tcpClient"> The client that requested moving </param>
        /// <returns>
        /// Sends to the other player a notification that this player has moved, as a jason</returns>
        public string PlayTurn(string movement, TcpClient tcpClient)
        {
            Game game;
            if (clientGameDictionary.TryGetValue(tcpClient, out game))
            {
                Console.WriteLine("game found");
                return game.MovePlayer(movement, tcpClient);
            }
            return "client is not participating in a game";
        }

        /// <summary>
        /// Sends a list of the available games to join.
        /// </summary>
        /// <returns>
        /// The list of the games to join </returns>
        public List<string> AvailableGames()
        {
            List<string> gameList = new List<string>();
            foreach (var game in this.gameDictionary)
            {
                if(!game.Value.IsOccuiped())
                gameList.Add(game.Value.GetName());
            }
            return gameList;
        }


        /// <summary>
        /// The close game.
        /// </summary>
        /// <param name="name">
        /// The name of the command
        /// </param>
        /// <param name="tcpClient">
        /// The client the might need to be closed
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CloseGame(string name, TcpClient tcpClient)
        {
            Game game;
            if(this.clientGameDictionary.TryGetValue(tcpClient, out game))
            {
                BinaryWriter clientStream;
                this.clientGameDictionary.Remove(game.GetPlayerOne().GetTcpClient());
                this.clientGameDictionary.Remove(game.GetPlayerTwo().GetTcpClient());
                this.gameDictionary.Remove(game.GetName());
                return game.CloseMessage(tcpClient);
            }
            return "Can't close the wanted game";
        }
    }
}
