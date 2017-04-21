
using ServerConsole.View;

namespace ServerConsole.TheController
{
    using System.Net.Sockets;
    using TheModel;

    /// <summary>
    /// An interface for the controller int the MVC.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Setter, sets the view.
        /// </summary>
        /// <param name="view"> The view </param>
        void SetView(IView view);

        /// <summary>
        /// Setter, sets the model.
        /// </summary>
        /// <param name="module">
        /// The model </param>
        void SetModel(IModel module);

        /// <summary>
        /// Executes the command requested by user. 
        /// </summary>
        /// <param name="commandLine"> What has been received from client.</param>
        /// <param name="tcpClient">
        /// The client we are talking to.</param>
        /// <returns>the respond from the command</returns>
        string ExecuteCommand(string commandLine, TcpClient tcpClient);


        /// <summary>
        /// Helps with closing the connections.
        /// </summary>
        /// <param name="commandLine">
        /// The command line.
        /// </param>
        /// <param name="client">
        /// The client.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>. true if the command was of single player kind
        /// </returns>
        bool CloseSingle(string commandLine, TcpClient client);
    }
}
