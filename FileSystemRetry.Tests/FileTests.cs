using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using System.Diagnostics;
using System.IO.Abstractions;
using FileWrapper = SampleWorker.FileWrapper;

namespace FileSystemRetry.Tests
{
    public class FileTests
    {

        private FileWrapper GetFileWrapper(RetryPolicy? retryPolicy = null, IFileSystem? fileSystem = null)
        {
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostingContext, services) =>
                {
                    var retryPolicyToUse = retryPolicy ?? new RetryPolicy(1, new List<Type> { typeof(FileNotFoundException) }, RetryIntervalFunction.RetryIntervalStatic(1));
                    services.AddRetryFileSystem(retryPolicyToUse, fileSystem);
                    services.AddSingleton<FileWrapper>();
                })
                .Build();

            var fileWrapper = host.Services.GetRequiredService<FileWrapper>();

            return fileWrapper;
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void GetFileToRead_FileDoesntExists_TriesXTimesAccordingToPolicyAndFails(int retriesNumber)
        {
            // Arrange
            var fileName = "MyFileName";
            var retryPolicy = new RetryPolicy(retriesNumber, new List<Type> { typeof(FileNotFoundException) }, RetryIntervalFunction.RetryIntervalStatic(1));
            var mockFileSystem = new Mock<IFileSystem>();
            mockFileSystem.Setup(mfs => mfs.File.OpenRead(fileName)).Throws(new FileNotFoundException());

            var fileWrapper = GetFileWrapper(retryPolicy, mockFileSystem.Object);
            Assert.NotNull(fileWrapper);
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Act
            Assert.Throws<FileNotFoundException>(() => fileWrapper.OpenFileRead(fileName));

            // Assert
            stopwatch.Stop();
            mockFileSystem.Verify(mfs => mfs.File.OpenRead(fileName), Times.Exactly(retriesNumber == 0 ? 1 : retriesNumber));
            if (retriesNumber > 0)
            {
                Assert.True(stopwatch.Elapsed.TotalSeconds >= retriesNumber - 1);
                Assert.True(stopwatch.Elapsed.TotalSeconds <= retriesNumber + 2);
            }
        }

        [Theory]
        [InlineData(10, true)]
        [InlineData(100, false)]
        public void CheckFileExists_DoesntExists_DoesntTryMoreThanOnce(int retriesNumber, bool returnValue)
        {
            // Arrange
            var fileName = "MyFileName";
            var retryPolicy = new RetryPolicy(retriesNumber, new List<Type> { typeof(FileNotFoundException) }, RetryIntervalFunction.RetryIntervalStatic(1));
            var mockFileSystem = new Mock<IFileSystem>();
            mockFileSystem.Setup(mfs => mfs.File.Exists(fileName)).Returns(returnValue);

            var fileWrapper = GetFileWrapper(retryPolicy, mockFileSystem.Object);
            Assert.NotNull(fileWrapper);

            // Act
            var result = fileWrapper.FileExists(fileName);

            // Assert
            Assert.Equal(returnValue, result);
            mockFileSystem.Verify(mfs => mfs.File.Exists(fileName), Times.Exactly(1));
        }
    }
}