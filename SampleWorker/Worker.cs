using System.IO.Abstractions;

namespace SampleWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileSystem _fileSystem;

        public Worker(ILogger<Worker> logger, IFileSystem fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                Console.WriteLine(_fileSystem.File.OpenRead("appsettingsdsadsa.json"));
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}