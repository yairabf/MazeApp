namespace ClientConsole
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
