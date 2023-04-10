using FileSystemRetry;
using SampleWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
    {
        services.AddRetryFileSystem(new RetryPolicy(1, new List<Type> { typeof(FileNotFoundException) }, TimeSpan.FromSeconds(1)));
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
