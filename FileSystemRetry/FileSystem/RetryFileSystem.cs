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

        public IDirectoryInfoFactory DirectoryInfo => throw new NotImplementedException();

        public IDriveInfoFactory DriveInfo => throw new NotImplementedException();

        public IFile File => new RetryFile(_retryHandler, _innerFileSystem);

        public IFileInfoFactory FileInfo => throw new NotImplementedException();

        public IFileStreamFactory FileStream => throw new NotImplementedException();

        public IFileSystemWatcherFactory FileSystemWatcher => throw new NotImplementedException();

        public IPath Path => throw new NotImplementedException();
    }
}
