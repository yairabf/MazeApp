using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    /// <summary>
    /// A class to run the client.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Client client = new Client();
            client.SendCommands();
        }
    }
}
