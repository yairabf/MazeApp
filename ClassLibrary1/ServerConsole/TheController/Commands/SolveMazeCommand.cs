﻿
namespace ServerConsole.TheController.Commands
{
    using System.Net.Sockets;
    using ClassLibrary1;
    using MazeLib;
    using Newtonsoft.Json.Linq;
    using TheModel;

    /// <summary>
    /// A class for the solve command.
    /// </summary>
    public class SolveMazeCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolveMazeCommand"/> class. 
        /// </summary>
        /// <param name="model">
        /// The model 
        /// </param>
        public SolveMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns>the respond from the command</returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int algorithm = int.Parse(args[1]);
            ISolution<Position> solution = this.model.Solve(name, algorithm);
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
