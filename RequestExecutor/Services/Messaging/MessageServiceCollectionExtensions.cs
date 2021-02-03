using RequestExecutor.Options;
using RequestExecutor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
