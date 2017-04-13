﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using ClassLibrary1;

class Program
    {
        public static void Main(string[] args)
        {
            compareSolvers();
        }

        public static void compareSolvers()
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(10, 10);
            Console.WriteLine(maze.ToString());
            DFS<Position> bfs = new DFS<Position>();
            MazeToSearchableAdapter adapter = new MazeToSearchableAdapter(maze);
            Solution<Position> bfsSolution = bfs.Search(adapter);
            bfsSolution.printSolution();
            Console.WriteLine(bfs.getNumberOfNodesEvaluated());
            //the same for dfs
        }


    }