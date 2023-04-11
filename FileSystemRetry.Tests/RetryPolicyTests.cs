using FileSystemRetry.Policy;

namespace FileSystemRetry.Tests
{
    public class RetryPolicyTests
    {
        [Fact]
        public void CreatePolicy_CorrectArgumentsNullList_CreationSuccess()
        {
            // Arrange
            // Act
            RetryPolicy retryPolicy = new RetryPolicy(1, null, RetryIntervalFunction.RetryIntervalStatic(1));

            // Assert
            Assert.NotNull(retryPolicy);
            Assert.Equal(1, retryPolicy.NumberOfRetries);
            Assert.Equal(1, retryPolicy.RetryFunction(1).TotalSeconds);
            Assert.Null(retryPolicy.ExceptionsToRetry);
        }

        [Fact]
        public void CreatePolicy_CorrectArgumentsNotNullList_CreationSuccess()
        {
            // Arrange
            // Act
            RetryPolicy retryPolicy = new RetryPolicy(1, new List<Type> { typeof(ArgumentNullException) }, RetryIntervalFunction.RetryIntervalStatic(1));

            // Assert
            Assert.NotNull(retryPolicy);
            Assert.Equal(1, retryPolicy.NumberOfRetries);
            Assert.Equal(1, retryPolicy.RetryFunction(1).TotalSeconds);
            Assert.NotNull(retryPolicy.ExceptionsToRetry);
            Assert.Contains(typeof(ArgumentNullException), retryPolicy.ExceptionsToRetry);
        }

        [Fact]
        public void CreatePolicy_DefaultPolicy_CreationSuccess()
        {
            // Arrange
            // Act
            RetryPolicy retryPolicy = RetryPolicy.Default;

            // Assert
            Assert.NotNull(retryPolicy);
            Assert.Equal(3, retryPolicy.NumberOfRetries);
            Assert.Equal(3, retryPolicy.RetryFunction(1).TotalSeconds);
            Assert.Null(retryPolicy.ExceptionsToRetry);
        }

        [Fact]
        public void CreatePolicy_CorrectArgumentsListContainsOnlyTypeNotException_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RetryPolicy(1, new List<Type> { typeof(string) }, RetryIntervalFunction.RetryIntervalStatic(1)));
        }
        [Fact]
        public void CreatePolicy_CorrectArgumentsListContainsTypeNotException_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RetryPolicy(1, new List<Type> { typeof(ArgumentNullException), typeof(string) }, RetryIntervalFunction.RetryIntervalStatic(1)));
        }

        [Fact]
        public void CreatePolicy_NegativeRetryNumber_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RetryPolicy(-1, null, RetryIntervalFunction.RetryIntervalStatic(1)));
        }

        [Fact]
        public void CreatePolicy_NegativeTimeSpan_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new RetryPolicy(1, null, RetryIntervalFunction.RetryIntervalStatic(-1)));
        }
    }
}
