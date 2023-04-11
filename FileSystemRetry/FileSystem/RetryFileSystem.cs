using FileSystemRetry.Handler;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryFileSystem : IFileSystem
    {
        private IRetryHandler _retryHandler;
        private IFileSystem _innerFileSystem;

        public RetryFileSystem(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _retryHandler = retryHandler;
            _innerFileSystem = innerFileSystem;
        }

        public IDirectory Directory => new RetryDirectory(_retryHandler, _innerFileSystem);

        public IDirectoryInfoFactory DirectoryInfo => new RetryDirectoryInfoFactory(_retryHandler, _innerFileSystem);

        public IDriveInfoFactory DriveInfo => new RetryDriveInfoFactory(_retryHandler, _innerFileSystem);

        public IFile File => new RetryFile(_retryHandler, _innerFileSystem);

        public IFileInfoFactory FileInfo => new RetryFileInfoFactory(_retryHandler, _innerFileSystem);

        public IFileStreamFactory FileStream => new RetryFileStreamFactory(_retryHandler, _innerFileSystem);

        public IFileSystemWatcherFactory FileSystemWatcher => new RetryFileSystemWatcherFactory(_retryHandler, _innerFileSystem);

        public IPath Path => new RetryPath(_retryHandler, _innerFileSystem);
    }
}
