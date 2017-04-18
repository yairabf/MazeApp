using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using MazeLib;

namespace ClassLibrary1
{
    class MazeSolution : Solution<Position >
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
                string solutionAsString = string.Empty;
                while (solutionList.Any())
                {
                    State<Position> state = solutionList.Pop();
                    int movementJ = state.GetState().Col - solutionList.Peek().GetState().Col;
                    int movementI = state.GetState().Row - solutionList.Peek().GetState().Row;
                    if (movementI != 0)
                    {
                        switch (movementI)
                        {
                            case 1:
                                solutionAsString += '2';
                                break;
                            case -1:
                                solutionAsString += '3';
                                break;
                        }
                    }
                    else
                    {
                        switch (movementJ)
                        {
                            case 1:
                                solutionAsString += '0';
                                break;
                            case -1:
                                solutionAsString += '1';
                                break;
                        }
                    }

                }
                if (solutionAsString.Length == 0)
                    return "There is maze to solve";
                return solutionAsString;
            }

            public int GetEvaluatedNodes()
            {
                return this.nodesEvaluated;
            }
        }
}
