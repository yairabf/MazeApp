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
            BFS<Position> bfs = new BFS<Position>();
            DFS<Position> dfs = new DFS<Position>();
            MazeToSearchableAdapter adapter = new MazeToSearchableAdapter(maze);
            Solution<Position> bfsSolution = bfs.Search(adapter);
            bfsSolution.printSolution();
            Console.WriteLine(bfs.getNumberOfNodesEvaluated());
            Solution<Position> dfsSolution = dfs.Search(adapter);
            dfsSolution.printSolution();
            Console.WriteLine(dfs.getNumberOfNodesEvaluated());
            //the same for dfs
        }


    }
}
