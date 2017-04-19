

using System;

namespace ServerConsole
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    class Controller : IController
    {
        private IView view;

        private IModel model;

        private Dictionary<string, ICommand> commands;

        public Controller()
        {
            model = new Model(); 
            this.commands = new Dictionary<string, ICommand>();
            commands.Add("generate", new GenerateMazeCommand(this.model));
            commands.Add("solve", new SolveMazeCommand(this.model));
            commands.Add("start", new StartGameCommand(this.model));
            commands.Add("join", new JoinGameCommand(this.model));
            commands.Add("list", new ListCommand(this.model));
            commands.Add("play", new JoinGameCommand(this.model));
            commands.Add("close", new JoinGameCommand(this.model));
        }

        public void SetView(IView v)
        {
            this.view = v;
        }

        public void SetModel(IModel m)
        {
            this.model = m;
            
        }

        public string ExecuteCommand(string commandLine, TcpClient tcpClient)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            Console.WriteLine("start command");
            return command.Execute(args, tcpClient);
        }
    }
}
