using FileSystemRetry;
using SampleWorker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
    {
        var retryPolicy = new RetryPolicy(1, new List<Type> { typeof(FileNotFoundException) }, RetryIntervalFunction.RetryIntervalStatic(1));
        
        services.AddRetryFileSystem(retryPolicy)
            .AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
