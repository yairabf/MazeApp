using System;
using System.Collections;
using System.Collections.Generic;
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



        public Model()
        {
            mazes = new Dictionary<string, Maze>();
            bfsMazes = new Dictionary<string, ISolution<Position>>();
            dfsMazes = new Dictionary<string, ISolution<Position>>();
            gameDictionary = new Dictionary<string, Game>();
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
            Console.WriteLine("in model function");
            ISolution<Position> solvedMaze;
            if (algorithm == 0)
            {
                Console.WriteLine("in model function bfs solution");
                if (this.bfsMazes.TryGetValue(name, out solvedMaze))
                {
                    return solvedMaze;
                }
                Maze maze;
                if (this.mazes.TryGetValue(name, out maze))
                {
                    Console.WriteLine("in model function mazes");
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
            return "Waiting for second player";
        }

        public string JoinGame(string gameName, TcpClient tcpClient)
        {
            Game game;
            if (gameDictionary.TryGetValue(gameName, out game))
            {
                game.SetPlayerTwo(new Player("PlayerTwo", tcpClient));
                return game.SendStartingMessages();
            }
            return "Game does not exist";
        }


    }
}
