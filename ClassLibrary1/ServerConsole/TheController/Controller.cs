
namespace ServerConsole.TheController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using Commands;
    using TheModel;

    /// <summary>
    /// A class for the controller of the MVC.
    /// </summary>
    public class Controller : IController
    {
        /// <summary>
        /// The view 
        /// </summary>
        private IView view;

        /// <summary>
        /// The model.
        /// </summary>
        private IModel model;

        /// <summary>
        /// a dictionary that contains the command available.
        /// </summary>
        private Dictionary<string, ICommand> commands;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class.
        /// </summary>
        public Controller()
        {
            model = new Model(); 
            this.commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(this.model));
            commands.Add("solve", new SolveMazeCommand(this.model));
            commands.Add("start", new StartGameCommand(this.model));
            commands.Add("join", new JoinGameCommand(this.model));
            commands.Add("list", new ListCommand(this.model));
            commands.Add("play", new PlayCommand(this.model));
            commands.Add("close", new CloseCommand(this.model));
        }

        /// <summary>
        /// Setter for the view. 
        /// </summary>
        /// <param name="v">
        /// The view </param>
        public void SetView(IView v)
        {
            this.view = v;
        }

        /// <summary>
        /// Setter for the model.
        /// </summary>
        /// <param name="m">
        /// The model </param>
        public void SetModel(IModel m)
        {
            this.model = m;
            
        }

        /// <summary>
        /// Finds the correct command and causes it to execute itself.
        /// </summary>
        /// <param name="commandLine"> The string received from user </param>
        /// <param name="tcpClient"> The client we are talking to </param>
        /// <returns> A string for the client. Will be sent from the client handler </returns>
        public string ExecuteCommand(string commandLine, TcpClient tcpClient)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
            {
                return "Command not found";
            }
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, tcpClient);
        }

        /// <summary>
        /// Checks if the command is single or multy.
        /// </summary>
        /// <param name="commandLine"> The string received from user </param>
        /// <param name="client"> The client we are talking to </param>
        /// <returns>the respond from the command</returns>
        public bool CloseSingle(string commandLine, TcpClient client)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                Console.WriteLine("command not found");
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            /*if(command.GetIsSingle())
                client.Close();*/
            return command.GetIsSingle();
        }
    }
}
