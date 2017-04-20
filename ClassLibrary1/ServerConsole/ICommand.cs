

namespace ServerConsole
{
    using System.Net.Sockets;
    internal interface ICommand
    {
        string Execute(string[] args, TcpClient client = null);

        bool GetIsSingle();
    }
}
