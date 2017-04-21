
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
    /// <summary>
    /// An interface for the controler int the MVC.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Setter, sets the biew.
        /// </summary>
        /// <param name="view"> The view </param>
        void SetView(IView view);

        /// <summary>
        /// Setter, sets the model.
        /// </summary>
        /// <param name="module">
        ///  The model </param>
        void SetModel(IModel module);

        /// <summary>
        /// Executes the command requested by user. 
        /// </summary>
        /// <param name="commandLine"> What has been received from client.</param>
        /// <param name="tcpClient">
        /// The client we are talking to.</param>
        /// <returns></returns>
        string ExecuteCommand(string commandLine, TcpClient tcpClient);

        /// <summary>
        /// Helps with closing the connections.
        /// </summary>
        /// <param name="commandLine"> What has been received from client.</param>
        /// <param name="client">
        /// <returns></returns>
        bool CloseSingle(string commandLine, TcpClient client);
    }
}
