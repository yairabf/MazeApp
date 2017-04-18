using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Solution<T> : ISolution<T>
    {
        protected int nodesEvaluated;

        public Solution()
        {
            nodesEvaluated = 0;
        }

        public abstract void BuildSolution(State<T> goal, int nodes);

        public void SetNodeEvaluated(int node)
        {
            this.nodesEvaluated = node;
        }

        public int GetNodeEvaluated()
        {
            return this.nodesEvaluated;
        }

        public abstract void PrintSolution();

        public abstract string ToString();


    }
}
