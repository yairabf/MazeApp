﻿

using System.Net.Sockets;

namespace ServerConsole.TheController.Commands
{
    /// <summary>
    /// An interface for the commands.
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Executes the command using model.
        /// </summary>
        /// <param name="args"> The name </param>
        /// <param name="client"> The client that sent the command </param>
        /// <returns>The respond of the execution</returns>
        string Execute(string[] args, TcpClient client = null);

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns>
        /// True if is a single type command, otherwise false </returns>
        bool GetIsSingle();
    }
}
