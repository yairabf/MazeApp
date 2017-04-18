using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ClassLibrary1
{
    public interface ISolution<T>
    { 
        /**
         * receives a goal state and builds the solution
         * 
         */
        void BuildSolution(State<T> goal, int nodes);

        void SetNodeEvaluated(int node);

        int GetNodeEvaluated();

        void PrintSolution();

        string ToString();

    }
}
