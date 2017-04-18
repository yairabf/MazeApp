using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ClassLibrary1
{
    class MazeSolution : Solution<Position>
    {
        private Stack<State<Position>> solutionList;

        public MazeSolution()
        {
            solutionList = new Stack<State<Position>>();
        }
        /**
         * receives a goal state and builds the solution
         * 
         */
        public override void BuildSolution(State<Position> goal, int nodes)
        {
            while (goal != null)
            {
                solutionList.Push(goal);
                goal = goal.GetCameFrom();
            }
            this.nodesEvaluated = nodes;
        }

        public override void PrintSolution()
        {
            foreach (State<Position> s in solutionList)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public override string ToString()
        {
            Stack<State<Position>> sol = new Stack<State<Position>>(this.solutionList.Reverse());
            
            StringBuilder solutionAsString = new StringBuilder("");
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
                return "There is maze to solve";
            // Console.WriteLine(solutionAsString.ToString());
            return solutionAsString.ToString();
            }
    

        public int GetEvaluatedNodes()
        {
            return this.nodesEvaluated;
        }
    }
}
