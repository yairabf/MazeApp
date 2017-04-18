using System;
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
