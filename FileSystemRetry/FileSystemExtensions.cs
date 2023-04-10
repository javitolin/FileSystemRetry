using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

namespace FileSystemRetry
{
    public static class FileSystemExtensions
    {

        public static IServiceCollection AddRetryFileSystem(this IServiceCollection services, RetryPolicy retryPolicy)
        {
            return services.AddSingleton(retryPolicy)
                .AddSingleton<IFileSystem, FileSystem>()
                .Decorate<IFileSystem, RetryFileSystem>();
        }
    }
}
