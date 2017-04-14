﻿

namespace ConsoleApp3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    class Client
    {
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
        TcpClient client = new TcpClient();

        Console.WriteLine("You are connected");
        using (NetworkStream stream = client.GetStream())
        using (BinaryReader reader = new BinaryReader(stream))
            using (BinaryWriter writer = new BinaryWriter(stream))
        {
            // Send data to server
            Console.Write("Please enter a number: ");
            int num = int.Parse(Console.ReadLine());
            writer.Write(num);
            // Get result from server
            int result = reader.ReadInt32();
            Console.WriteLine("Result = {0}", result);
        }
        client.Close();
    }
}
