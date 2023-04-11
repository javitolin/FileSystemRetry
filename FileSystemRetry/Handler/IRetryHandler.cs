namespace FileSystemRetry.Handler
{
    public interface IRetryHandler
    {
        void HandleRetryFunction(Action toRetry);
        T HandleRetryFunction<T>(Func<T> toRetry);
        bool ShouldRetry(ref int retryCount, Exception ex);
    }
}