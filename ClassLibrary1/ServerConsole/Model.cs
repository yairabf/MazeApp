using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ServerConsole
{
    using MazeGeneratorLib;
    using MazeLib;

    class Model : IModel
    {
        private Dictionary<string, Maze> mazes;
        private Dictionary<string, ISolution<Position>> bfsMazes;
        private Dictionary<string, ISolution<Position>> dfsMazes;
        private Dictionary<string, Game> gameDictionary;
        private Dictionary<TcpClient, Game> clientGameDictionary;



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
            //Console.WriteLine("in model function");
            ISolution<Position> solvedMaze;
            if (algorithm == 0)
            {
                //Console.WriteLine("in model function bfs solution");
                if (this.bfsMazes.TryGetValue(name, out solvedMaze))
                {
                    return solvedMaze;
                }
                Maze maze;
                if (this.mazes.TryGetValue(name, out maze))
                {
                    //Console.WriteLine("in model function mazes");
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

        public string JoinGame(string gameName, TcpClient tcpClient)
        {
            Game game;
            if (gameDictionary.TryGetValue(gameName, out game))
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
            return "Game does not exist or occuiped";
        }

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

        public List<string> AvaliableGames()
        {
            List<string> gameList = new List<string>();
            foreach (var game in this.gameDictionary)
            {
                if(!game.Value.IsOccuiped())
                gameList.Add(game.Value.GetName());
            }
            return gameList;
        }

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
