using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryFileSystemWatcherFactory : IFileSystemWatcherFactory
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryFileSystemWatcherFactory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        [Obsolete("Use `IFileSystemWatcherFactory.New()` instead")]
        public IFileSystemWatcher CreateNew()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.CreateNew());
        }

        [Obsolete("Use `IFileSystemWatcherFactory.New(string)` instead")]
        public IFileSystemWatcher CreateNew(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.CreateNew(path));
        }

        [Obsolete("Use `IFileSystemWatcherFactory.New(string, string)` instead")]
        public IFileSystemWatcher CreateNew(string path, string filter)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.CreateNew(path, filter));
        }

        public IFileSystemWatcher New()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.New());
        }

        public IFileSystemWatcher New(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.New(path));
        }

        public IFileSystemWatcher New(string path, string filter)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.New(path, filter));
        }

        [return: NotNullIfNotNull("fileSystemWatcher")]
        public IFileSystemWatcher? Wrap(FileSystemWatcher? fileSystemWatcher)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileSystemWatcher.Wrap(fileSystemWatcher));
        }
        #endregion
    }
}
