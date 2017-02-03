using System;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace Ping
{
    public class PongHandler : IHandleMessages<Pong>
    {
        static Random _rand = new Random();

        public async Task Handle(Pong message, IMessageHandlerContext context)
        {
            Console.WriteLine("Pong received");

            await Task.Delay(_rand.Next(1000, 10000));
            await context.Send("Pong", new Messages.Ping());
        }
    }
}
