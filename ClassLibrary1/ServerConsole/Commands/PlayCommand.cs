﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class PlayCommand
    {
        private IModel model;

        public PlayCommand(IModel model)
        {
            this.model = model;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string movement = args[0];
            return this.model.PlayTurn(movement, client);
        }
    }
}
