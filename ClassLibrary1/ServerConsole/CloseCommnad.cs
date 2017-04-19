﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ServerConsole
{
    class CloseCommnad : ICommand
    {
        private IModel model;

        public CloseCommnad(IModel m)
        {
            this.model = m;
        }

        public string Execute(string[] args, TcpClient client = null)
        {
            string name = args[0];
            return model.CloseGame(name, client);
        }
    }
}
