namespace FileSystemRetry
{
    public class RetryPolicy
    {
        public int NumberOfRetries { get; set; }
        public List<Type> ExceptionsToRetry { get; set; } = new List<Type>();
        public TimeSpan RetryInterval { get;set; }


        public RetryPolicy() { }
        public RetryPolicy(int numberOfRetries, List<Type> exceptionsToRetry, TimeSpan retryInterval)
        {
            NumberOfRetries = numberOfRetries;
            ExceptionsToRetry = exceptionsToRetry;
            RetryInterval = retryInterval;
        }
    }
}
