using System;
using System.Net.Sockets;
using ClassLibrary1;
using MazeLib;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
    /// <summary>
    /// A class for the solve command.
    /// </summary>
    class SolveMazeCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="model"> The model </param>
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns></returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            //Console.WriteLine("calling model");
            ISolution<Position> solution = this.model.Solve(name, algorithm);
            //Console.WriteLine("got the solution");
            JObject solutionObj = new JObject();
            solutionObj["Name"] = name;
            solutionObj["solution"] = solution.ToString();
            solutionObj["NodesEvaluated"] = solution.GetNodeEvaluated();
            return solutionObj.ToString();
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        public bool GetIsSingle()
        {
            return true;
        }
    }
}
