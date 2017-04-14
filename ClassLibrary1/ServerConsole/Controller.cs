

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
            this.commands = new Dictionary<string, ICommand>();
        }

        public void SetView(IView v)
        {
            this.view = v;
        }

        public void SetModel(IModel m)
        {
            this.model = m;
            commands.Add("generate", new GenerateMazeCommand(model));

        }

        public string ExecuteCommand(string commandLine, TcpClient tcpClient)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            return command.Execute(args, tcpClient);
        }
    }
}
