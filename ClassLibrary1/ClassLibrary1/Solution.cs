using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void buildSolution(State<T> goal)
        {
            while(goal != null)
            {
                solutionList.Push(goal);
                goal = goal.getCameFrom();
            }
        }

        public void printSolution()
        {
            foreach (State<T> s in solutionList)
            {
                Console.WriteLine(s.ToString());
            }
        }
    }
}
