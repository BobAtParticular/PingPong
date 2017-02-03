using System;
using System.Threading.Tasks;

namespace Pong
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointName = "Pong";
            Console.Title = endpointName;
            EndpointStartup.Start(endpointName, i => Task.CompletedTask).GetAwaiter().GetResult();
        }
    }
}
