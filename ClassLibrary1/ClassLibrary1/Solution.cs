﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ClassLibrary1
{
    public class Solution<T>
    {
        private int nodesEvaluated;
        private Stack<State<T>> solutionList;

        public Solution()
        {
            solutionList = new Stack<State<T>>();       
        }
        /**
         * receives a goal state and builds the solution
         * 
         */
        public void BuildSolution(State<T> goal, int nodes)
        {
            while(goal != null)
            {
                solutionList.Push(goal);
                goal = goal.GetCameFrom();
            }
            this.nodesEvaluated = nodes;
        }

        public void PrintSolution()
        {
            foreach (State<T> s in solutionList)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public override string ToString()
        {
            string solutionAsString = string.Empty;
            while (solutionList.Count != 0)
            {
                State < T > state = solutionList.Pop();
                solutionAsString += state.ToString();
            }
            return solutionAsString;
        }

        public int GetEvaluatedNodes()
        {
            return this.nodesEvaluated;
        }
    }
}
