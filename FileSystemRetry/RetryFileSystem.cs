using Microsoft.Extensions.Logging;
using System.IO.Abstractions;

namespace FileSystemRetry
{
    public class RetryFileSystem : IFileSystem
    {
        private RetryPolicy _retryPolicy;
        private ILogger<IFileSystem>? _logger;
        private IFileSystem _realFileSystem;

        public RetryFileSystem(RetryPolicy retryPolicy, ILogger<IFileSystem>? logger, IFileSystem realFileSystem)
        {
            _retryPolicy = retryPolicy;
            _logger = logger;
            _realFileSystem = realFileSystem;
        }


        public IDirectory Directory => throw new NotImplementedException();

        public IDirectoryInfoFactory DirectoryInfo => throw new NotImplementedException();

        public IDriveInfoFactory DriveInfo => throw new NotImplementedException();

        public IFile File => new RetryFile(_retryPolicy, _realFileSystem, _logger);

        public IFileInfoFactory FileInfo => throw new NotImplementedException();

        public IFileStreamFactory FileStream => throw new NotImplementedException();

        public IFileSystemWatcherFactory FileSystemWatcher => throw new NotImplementedException();

        public IPath Path => throw new NotImplementedException();
    }
}
