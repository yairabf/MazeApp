using System.Net.Sockets;

namespace ServerConsole.View
{
    /// <summary>
    /// An interface for the client handler.
    /// </summary>
    interface IClientHandler : IView
    {
        /// <summary>
        /// Handles a client. Invoked by Server.
        /// </summary>
        /// <param name="client"> The client we are talking to </param>
        void HandleClient(TcpClient client);
    }
}
