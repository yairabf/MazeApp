﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(263501, new ClientHandler());
            server.Start();
        }
    }
}
