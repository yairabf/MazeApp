using System;
using System.Net.Sockets;
using ClassLibrary1;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
    class SolveMazeCommand : ICommand
    {
        private IModel model;

        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            Console.WriteLine("calling model");
            ISolution<Position> solution = this.model.Solve(name, algorithm);
            Console.WriteLine("got the solution");
            //return solution.ToJason();
            JObject solutionObj = new JObject();
            solutionObj["Name"] = name;
            solutionObj["solution"] = solution.ToString();
            Console.WriteLine(solution.ToString());
            solutionObj["NodesEvaluated"] = solution.GetNodeEvaluated();
            return solutionObj.ToString();
        }
    }
}
