using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryDirectoryInfoFactory : IDirectoryInfoFactory
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryDirectoryInfoFactory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        [Obsolete("Use `IDirectoryInfoFactory.New(string)` instead")]
        public IDirectoryInfo FromDirectoryName(string directoryName)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DirectoryInfo.FromDirectoryName(directoryName));
        }

        public IDirectoryInfo New(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DirectoryInfo.New(path));
        }

        [return: NotNullIfNotNull("directoryInfo")]
        public IDirectoryInfo? Wrap(DirectoryInfo? directoryInfo)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DirectoryInfo.Wrap(directoryInfo));
        }
        #endregion
    }
}
