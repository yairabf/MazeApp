

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
            //DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            //Maze maze1 = mazeGenerator.Generate(10, 10);
            //Console.WriteLine(maze1.ToString());
            Bfs<Position> bfs = new Bfs<Position>();
            Dfs<Position> dfs = new Dfs<Position>();
            string json = @"{
                'Name': 'mymaze',
                'Maze':
                '0001010001010101110101010000010111111101000001000111010101110001010001011111110100000000011111111111',
                'Rows': 10,
                'Cols': 10,
                'Start': {
                    'Row': 0,
                    'Col': 4
                },
                'End': {
                    'Row': 0,
                    'Col': 0
                }
            }";
            Maze maze = Maze.FromJSON(json);
            Console.Write(maze.ToString());
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
