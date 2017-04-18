<<<<<<< HEAD
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
        private Stack<State<T>> solutionList;

        public Solution()
        {
            solutionList = new Stack<State<T>>();       
        }
        /**
         * receives a goal state and builds the solution
         * 
         */
        public void BuildSolution(State<T> goal)
        {
            while(goal != null)
            {
                solutionList.Push(goal);
                goal = goal.GetCameFrom();
            }
        }

        public void PrintSolution()
        {
            foreach (State<T> s in solutionList)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public string ToJason()
        {
            JObject mazeObj = new JObject();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ClassLibrary1
{
    public interface Solution<T>
    { 
        /**
         * receives a goal state and builds the solution
         * 
         */
        void BuildSolution(State<T> goal, int nodes);

        void PrintSolution();

        string ToString();

        int GetEvaluatedNodes();

    }
}
>>>>>>> e4383228fb054b6834708d69bc8bfbcf4f6e5a87
