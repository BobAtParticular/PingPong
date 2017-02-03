using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace Pong
{
    public class PingHandler : IHandleMessages<Ping>
    {
        static Random _rand = new Random();

        public async Task Handle(Ping message, IMessageHandlerContext context)
        {
            Console.WriteLine("Ping received");

            await Task.Delay(_rand.Next(2000, 20000));

            await context.Send("Ping", new Messages.Pong());
        }
    }
}
