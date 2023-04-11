using FileSystemRetry.FileSystem;
using FileSystemRetry.Handler;
using FileSystemRetry.Policy;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace FileSystemRetry.Extension
{
    public static class FileSystemExtensions
    {
        public static IServiceCollection AddRetryFileSystem(this IServiceCollection services, RetryPolicy? retryPolicy = null, IFileSystem? fileSystemHandler = null)
        {
            var retryPolicyToUse = retryPolicy ?? RetryPolicy.Default;
            var innerFileSystem = fileSystemHandler ?? new System.IO.Abstractions.FileSystem();

            return services.AddSingleton(retryPolicyToUse)
                .AddSingleton<IRetryHandler, RetryHandler>()
                .AddSingleton<IFileSystem>(serviceProvider =>
                {
                    var retryHandler = serviceProvider.GetService<IRetryHandler>();
                    if (retryHandler == null)
                        throw new ArgumentException("Couldn't find a RetryHandler", nameof(IRetryHandler));

                    return new RetryFileSystem(retryHandler, innerFileSystem);
                });
        }
    }
}
