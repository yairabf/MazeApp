
namespace ServerConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
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
