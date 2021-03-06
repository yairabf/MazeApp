﻿

namespace ClassLibrary1.Maze
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Channels;
    using System.Text;
    using System.Threading.Tasks;
    using MazeLib;

    /// <summary>
    /// A class representing a maze.
    /// </summary>
    public class MazeSolution : Solution<Position>
    {
        /// <summary>
        /// A stack containing all the nodes for the solution
        /// </summary>
        private Stack<State<Position>> solutionList;

        /// <summary>
        /// Initializes a new instance of the <see cref="MazeSolution"/> class. 
        /// Creating new stack for the states.
        /// </summary>
        public MazeSolution()
        {
            solutionList = new Stack<State<Position>>();
        }
        
        /// <summary>
        /// Receives a goal state and builds a solution.
        /// </summary>
        /// <param name="goal"> Is the goal of solution </param>
        /// <param name="nodes"> Is the amount of nodes evaluated in the search </param>
        public override void BuildSolution(State<Position> goal, int nodes)
        {
            while (goal != null)
            {
                solutionList.Push(goal);
                goal = goal.GetCameFrom();
            }
            this.NodesEvaluated = nodes;
        }

        /// <summary>
        /// Prints the solution.
        /// </summary>
        public override void PrintSolution()
        {
            foreach (State<Position> s in solutionList)
            {
                Console.WriteLine(s.ToString());
            }
        }

        /// <summary>
        /// Converts the solution to a string.
        /// </summary>
        /// <returns>
        /// The solution as a string </returns>
        public override string ToString()
        {
            Stack<State<Position>> sol = new Stack<State<Position>>(this.solutionList.Reverse());
            
            StringBuilder solutionAsString = new StringBuilder(string.Empty);
            while (sol.Any())
            {
                State<Position> state = sol.Pop();
                if (sol.Any())
                {
                    int movementJ = state.GetState().Col - sol.Peek().GetState().Col;
                    int movementI = state.GetState().Row - sol.Peek().GetState().Row;
                    if (movementI != 0)
                    {
                        switch (movementI)
                        {
                            case 1:
                                solutionAsString.Append("2");
                                break;
                            case -1:
                                solutionAsString.Append("3");
                                break;
                        }
                    }
                    else
                    {
                        switch (movementJ)
                        {
                            case 1:
                                solutionAsString.Append("0");
                                break;
                            case -1:
                                solutionAsString.Append("1");
                                break;
                        }
                    }
                }
            }
            if (solutionAsString.Length == 0)
            {
                return "There is no maze to solve";
            }
            return solutionAsString.ToString();
            }
    
        /// <summary>
        /// Getter for the evaluated nodes.
        /// </summary>
        /// <returns>
        /// The number of nodes evaluated </returns>
        public int GetEvaluatedNodes()
        {
            return this.NodesEvaluated;
        }
    }
}
