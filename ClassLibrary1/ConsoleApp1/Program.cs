﻿
namespace ConsoleApp1
{
    using System;
    using ClassLibrary1;
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
            Solution<Position> bfsSolution = bfs.Search(adapter);
            bfsSolution.PrintSolution();
            Console.WriteLine(bfs.GetNumberOfNodesEvaluated());
            Solution<Position> dfsSolution = dfs.Search(adapter);
            dfsSolution.PrintSolution();
            Console.WriteLine(dfs.GetNumberOfNodesEvaluated());
        }
    }
}
