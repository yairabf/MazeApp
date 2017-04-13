using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace ClassLibrary1
{
    class Program
    {
        public static void main(string[] args)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(10,10);
            Console.WriteLine(maze.ToString());
            BFS<Position> bfs = new BFS<Position>();

        }
        

    }
}
