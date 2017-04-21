
namespace ServerConsole.TheModel
{
    using System.Collections.Generic;
    using System.Net.Sockets;
    using ClassLibrary1;
    using MazeLib;

    /// <summary>
    /// An interface for the model in the MVC.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Generates a Maze.
        /// </summary>
        /// <param name="name"> Name of the maze </param>
        /// <param name="rows"> Amount of rows </param>
        /// <param name="cols"> Amount of columns </param>
        /// <returns></returns>
        Maze Generate(string name, int rows, int cols);

        /// <summary>
        /// Solving the maze.
        /// </summary>
        /// <param name="name"> The name of the maze to be solved.</param>
        /// <param name="algorithm"> Which algorithm to use for the search </param>
        /// <returns>the solution of the maze named <param name="name"></param></returns>
        ISolution<Position> Solve(string name, int algorithm);

        //string Solve(string name, int algorithm);

        /// <summary>
        /// Starts the game, waits for join th=o add first player.
        /// </summary>
        /// <param name="gameName"> Name </param>
        /// <param name="rows"></param>
        /// <param name="rows"> Amount of rows </param>
        /// <param name="cols"> Amount of columns </param>
        /// <returns></returns>
        string StartGame(string gameName, int rows, int cols, TcpClient tcpClient);

        /// <summary>
        /// Joins an existing game. 
        /// </summary>
        /// <param name="gameName"> Name </param>
        /// <param name="tcpClient">The client we are talking to.</param>
        /// <returns></returns>
        string JoinGame(string gameName, TcpClient tcpClient);

        /// <summary>
        /// Plays a turn of a client.
        /// </summary>
        /// <param name="movement"> Where to go </param>
        /// <param name="tcpClient"> Which client to move </param>
        /// <returns></returns>
        string PlayTurn(string movement, TcpClient tcpClient);

        /// <summary>
        /// Closes the game.
        /// </summary>
        /// <param name="movement"> Where to go </param>
        /// <param name="tcpClient"> Which client to move </param>
        /// <returns></returns>
        string CloseGame(string movement, TcpClient tcpClient);


        /// <summary>
        /// The available games.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        List<string> AvailableGames();

    }
}
