

using ClassLibrary1.Algorithems;

namespace ConsoleApp1
{
    using System;
    using ClassLibrary1;
    using ClassLibrary1.Maze;
    using MazeGeneratorLib;
    using MazeLib;

    /// <summary>
    /// the Main program that runs everything
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CompareSolvers();
        }

        /// <summary>
        /// Compares the solvers.
        /// </summary>
        public static void CompareSolvers()
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(10, 10);
            Console.WriteLine(maze.ToString());
            Bfs<Position> bfs = new Bfs<Position>();
            Dfs<Position> dfs = new Dfs<Position>();
            MazeToSearchableAdapter adapter = new MazeToSearchableAdapter(maze);
            ISolution<Position> bfsSolution = bfs.Search(adapter);
            Console.WriteLine("bfs: " + bfs.GetNumberOfNodesEvaluated());
            ISolution<Position> dfsSolution = dfs.Search(adapter);
            Console.WriteLine("dfs: " + dfs.GetNumberOfNodesEvaluated());
            Console.WriteLine("Please enter to close");
            Console.ReadLine();
        }
    }
}
