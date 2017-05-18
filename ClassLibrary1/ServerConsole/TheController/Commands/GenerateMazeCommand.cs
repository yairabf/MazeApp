
namespace ServerConsole.TheController.Commands
{
    using System;
    using System.Net.Sockets;
    using MazeLib;
    using TheModel;

    /// <summary>
    /// A class for the generate command. 
    /// </summary>
    internal class GenerateMazeCommand : ICommand
    {
        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateMazeCommand"/> class. 
        /// </summary>
        /// <param name="model">
        /// The model 
        /// </param>
        public GenerateMazeCommand(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns>The respond of the execution</returns>
        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.Generate(name, rows, cols);
            return maze.ToJSON();
        }

        /// <summary>
        /// Getter .
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        public bool GetIsSingle()
        {
            return true;
        }
    }
}
