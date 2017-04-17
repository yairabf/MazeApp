using System;
using System.Net.Sockets;
using ClassLibrary1;
using MazeLib;

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
            Solution<Position> solution = this.model.Solve(name, algorithm);
            //return solution.ToJason();
            JObject mazeObj = new JObject();
            mazeObj["Name"] = ;
            mazeObj["Rows"] = Rows;
            mazeObj["Cols"] = Cols;
        }
    }
}
