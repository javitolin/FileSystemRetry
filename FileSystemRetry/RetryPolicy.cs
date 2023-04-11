namespace FileSystemRetry
{
    public class RetryPolicy
    {
        public int NumberOfRetries { get; set; }
        public List<Type>? ExceptionsToRetry { get; set; } = new List<Type>();
        public RetryIntervalFunction RetryIntervalFunction { get; set; }

        public TimeSpan RetryFunction(int retryNumber) => RetryIntervalFunction.Invoke(retryNumber);

        /// <summary>
        /// Default policy. 3 retries, 3 seconds between retries, retry all exceptions
        /// </summary>
        public static RetryPolicy Default => new RetryPolicy(3, null, RetryIntervalFunction.RetryIntervalStatic(3));


        /// <summary>
        /// Constructor for RetryPolicy
        /// </summary>
        /// <param name="numberOfRetries">The number of times to retry the action</param>
        /// <param name="exceptionsToRetry">A list of exceptions acceptable for retry. If null will retry All. All items should inherit from 'Exception' class</param>
        /// <param name="retryInterval">TimeSpan argument to wait between retries</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws exception if any of the parameters is incorrect</exception>
        public RetryPolicy(int numberOfRetries, List<Type>? exceptionsToRetry, RetryIntervalFunction retryFunction)
        {
            if (numberOfRetries < 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfRetries), $"{nameof(numberOfRetries)} can't be negative");

            if (exceptionsToRetry != null && exceptionsToRetry.Any(t => !t.IsSubclassOf(typeof(Exception))))
                throw new ArgumentOutOfRangeException(nameof(exceptionsToRetry), $"{nameof(exceptionsToRetry)} contains types that don't inherit from 'Exception'");

            NumberOfRetries = numberOfRetries;
            ExceptionsToRetry = exceptionsToRetry;
            RetryIntervalFunction = retryFunction;
        }


    }
}
