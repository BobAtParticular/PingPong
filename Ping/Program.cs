using System;
using NServiceBus;

namespace Ping
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointName = "Ping";
            Console.Title = endpointName;
            EndpointStartup.Start(endpointName, i =>
            {
                Console.WriteLine("Sending first Ping");
                return i.Send("Pong", new Messages.Ping());
            }).GetAwaiter().GetResult();
        }
    }
}
