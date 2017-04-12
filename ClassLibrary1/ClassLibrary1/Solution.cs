using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Solution<T>
    {
        private Stack<State<T>> solutionStack;

        public Solution()
        {
            solutionStack = new Stack<State<T>>();       
        }
        /**
         * receives a goal state and builds the solution
         * 
         */
        public void buildSolution(State<T> goal)
        {
            while(goal != null)
            {
                solutionStack.Push(goal);
                goal = goal.getCameFrom();
            }
        }

        public String toString()
        {
            if(solutionStack)
            {
                while(solutionStack.Count > 0)
                {
                    State state = solutionStack.Pop();
                    Console.WriteLine(state.ToString);
                }
            }
            else
            {
                Console.WriteLine("stack has not been initialized");
            }
        }
    }
}
