using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO.Abstractions;

namespace FileSystemRetry
{
    public static class FileSystemExtensions
    {
        public static IServiceCollection AddRetryFileSystem(this IServiceCollection services, RetryPolicy? retryPolicy = null, IFileSystem? fileSystemHandler = null)
        {
            var retryPolicyToUse = retryPolicy ?? RetryPolicy.Default;
            var fileSystemToUse = fileSystemHandler ?? new FileSystem();

            return services.AddSingleton<IFileSystem, FileSystem>()
                .AddSingleton<IFileSystem>(serviceProvider =>
                {
                    var logger = serviceProvider.GetService<ILogger<IFileSystem>>();
                    return new RetryFileSystem(retryPolicyToUse, logger, fileSystemToUse);
                });
        }
    }
}
