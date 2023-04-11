using FileSystemRetry.Policy;
using Microsoft.Extensions.Logging;
using System.IO.Abstractions;

namespace FileSystemRetry.Handler
{
    public class RetryHandler : IRetryHandler
    {
        private RetryPolicy _retryPolicy;
        private ILogger<IFileSystem>? _logger;

        public RetryHandler(RetryPolicy retryPolicy, ILogger<IFileSystem>? logger)
        {
            _retryPolicy = retryPolicy;
            _logger = logger;
        }

        public void HandleRetryFunction(Action toRetry)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    toRetry();
                    return;
                }
                catch (Exception ex)
                {
                    if (!ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public T HandleRetryFunction<T>(Func<T> toRetry)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    return toRetry();
                }
                catch (Exception ex)
                {
                    if (!ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool ShouldRetry(ref int retryCount, Exception ex)
        {
            var shouldRetryResult = true;

            _logger?.LogWarning($"Exception caught: [{ex}]. Retry [{retryCount}] out of [{_retryPolicy.NumberOfRetries}]");

            retryCount++;
            try
            {
                if (retryCount >= _retryPolicy.NumberOfRetries)
                {
                    shouldRetryResult = false;
                    return shouldRetryResult;
                }

                if (_retryPolicy.ExceptionsToRetry == null)
                {
                    shouldRetryResult = true;
                    return shouldRetryResult;
                }
                else
                {
                    shouldRetryResult = _retryPolicy.ExceptionsToRetry.Contains(ex.GetType());
                    return shouldRetryResult;
                }
            }
            finally
            {
                if (shouldRetryResult)
                {
                    Thread.Sleep(_retryPolicy.RetryFunction(retryCount));
                }
            }
        }
    }
}
