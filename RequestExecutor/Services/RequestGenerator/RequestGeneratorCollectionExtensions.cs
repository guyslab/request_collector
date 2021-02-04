using RequestExecutor.Options;
using RequestExecutor.Services;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RequestGeneratorCollectionExtensions
    {
        public static IServiceCollection AddRequestGenerator(this IServiceCollection services, Action<RequestGenerationOptions> setup)
        {
            services.Configure(setup);
            services.AddTransient<IRequestGenerator, DefaultRequestGenerator>();

            return services;
        }
    }
}
