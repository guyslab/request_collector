using RequestExecutor.Options;
using RequestExecutor.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MessageServiceCollectionExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, Action<MessageOptions> setup)
        {
            services.Configure(setup);
            services.AddSingleton<IMessageService, RmqMessageService>();

            return services;
        }
    }
}
