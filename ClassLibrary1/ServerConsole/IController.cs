
namespace ServerConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Configuration;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    public interface IController
    {
        void SetView(IView view);

        void SetModel(IModel module);

        string ExecuteCommand(string commandLine, TcpClient tcpClient);

        bool CloseSingle(string commandLine, TcpClient client);
    }
}
