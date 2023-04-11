namespace FileSystemRetry.Policy
{
    public class RetryIntervalFunction
    {
        public delegate TimeSpan RetryIntervalFunc(int retryNumber);

        private Func<int, TimeSpan> retryIntervalFunction { get; }

        public RetryIntervalFunction(RetryIntervalFunc retryIntervalFunc)
        {
            retryIntervalFunction = (retryNumber) => retryIntervalFunc(retryNumber);
        }

        public static RetryIntervalFunction RetryIntervalStatic(int seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            return new RetryIntervalFunction((retryNumber) => TimeSpan.FromSeconds(seconds));
        }

        public static RetryIntervalFunction RetryIntervalLinear(int seconds, int addSeconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            if (addSeconds < 0) throw new ArgumentOutOfRangeException(nameof(addSeconds));

            return new RetryIntervalFunction((retryNumber) => TimeSpan.FromSeconds(seconds + retryNumber * addSeconds));
        }

        public static RetryIntervalFunction RetryIntervalLog(int seconds)
        {
            if (seconds < 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            return new RetryIntervalFunction((retryNumber) => TimeSpan.FromSeconds(Math.Pow(2, seconds)));
        }

        public TimeSpan Invoke(int seconds)
        {
            return retryIntervalFunction(seconds);
        }
    }
}
