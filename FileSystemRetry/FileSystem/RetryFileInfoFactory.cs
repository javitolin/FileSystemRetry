using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryFileInfoFactory : IFileInfoFactory
    {
        public IFileSystem FileSystem => _innerFileSystem;

        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryFileInfoFactory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        [Obsolete("Use `IFileInfoFactory.New(string)` instead")]
        public IFileInfo FromFileName(string fileName)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileInfo.FromFileName(fileName));
        }

        public IFileInfo New(string fileName)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileInfo.New(fileName));
        }

        [return: NotNullIfNotNull("fileInfo")]
        public IFileInfo? Wrap(FileInfo? fileInfo)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileInfo.Wrap(fileInfo));
        }
        #endregion
    }
}
