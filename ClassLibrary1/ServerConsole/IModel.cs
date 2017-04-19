﻿
using System.Collections.Generic;
using System.Net.Sockets;
using ClassLibrary1;

namespace ServerConsole
{
    using MazeLib;

    public interface IModel
    {
        Maze Generate(string name, int rows, int cols);

        ISolution<Position> Solve(string name, int algorithm);

        //string Solve(string name, int algorithm);

        string StartGame(string gameName, int rows, int cols, TcpClient tcpClient);

        string JoinGame(string gameName, TcpClient tcpClient);

        string PlayTurn(string movement, TcpClient tcpClient);

        string CloseGame(string movement, TcpClient tcpClient);

        List<string> AvaliableGames();

    }
}
