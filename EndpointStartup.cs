using System;
using System.Threading.Tasks;
using NServiceBus;

class EndpointStartup
{
    internal static async Task Start(string endpointName, Func<IEndpointInstance, Task> action)
    {
        var endpointConfiguration = new EndpointConfiguration(endpointName);
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.SendFailedMessagesTo("error");

        endpointConfiguration.PurgeOnStartup(true);

        endpointConfiguration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace == "Messages");

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        await action(endpointInstance);

        try
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        finally
        {
            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}