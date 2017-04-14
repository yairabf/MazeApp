using System;
using ClassLibrary1;
using MazeGeneratorLib;
using MazeLib;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            CompareSolvers();
        }

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
            //the same for dfs
        }


    }
}
