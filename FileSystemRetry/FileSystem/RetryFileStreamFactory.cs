using FileSystemRetry.Handler;
using Microsoft.Win32.SafeHandles;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryFileStreamFactory : IFileStreamFactory
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryFileStreamFactory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode)` instead.")]
        public Stream Create(string path, FileMode mode)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode));
        }

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode, FileAccess)` instead.")]
        public Stream Create(string path, FileMode mode, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode, access));
        }

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode, FileAccess, FileShare)` instead.")]
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode, access, share));
        }

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode, FileAccess, FileShare, int)` instead.")]
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode, access, share, bufferSize));
        }

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode, FileAccess, FileShare, int, FileOptions)` instead.")]
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode, access, share, bufferSize, options));
        }

        [Obsolete("Use `IFileStreamFactory.New(string, FileMode, FileAccess, FileShare, int, bool)` instead.")]
        public Stream Create(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(path, mode, access, share, bufferSize, useAsync));
        }

        [Obsolete("Use `IFileStreamFactory.New(SafeFileHandle, FileAccess)` instead.")]
        public Stream Create(SafeFileHandle handle, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access));
        }

        [Obsolete("Use `IFileStreamFactory.New(SafeFileHandle, FileAccess, int)` instead.")]
        public Stream Create(SafeFileHandle handle, FileAccess access, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access, bufferSize));
        }

        [Obsolete("Use `IFileStreamFactory.New(SafeFileHandle, FileAccess, int, bool)` instead.")]
        public Stream Create(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access, bufferSize, isAsync));
        }

        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access) instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access));
        }

        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access, ownsHandle));
        }

        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access, int bufferSize) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access, ownsHandle, bufferSize));
        }

        [Obsolete("This method has been deprecated. Please use new Create(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync) instead, and optionally make a new SafeFileHandle with ownsHandle=false if needed. http://go.microsoft.com/fwlink/?linkid=14202")]
        public Stream Create(IntPtr handle, FileAccess access, bool ownsHandle, int bufferSize, bool isAsync)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Create(handle, access, ownsHandle, bufferSize, isAsync));
        }

        public FileSystemStream New(SafeFileHandle handle, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(handle, access));
        }

        public FileSystemStream New(SafeFileHandle handle, FileAccess access, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(handle, access, bufferSize));
        }

        public FileSystemStream New(SafeFileHandle handle, FileAccess access, int bufferSize, bool isAsync)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(handle, access, bufferSize, isAsync));
        }

        public FileSystemStream New(string path, FileMode mode)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode));
        }

        public FileSystemStream New(string path, FileMode mode, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode, access));
        }

        public FileSystemStream New(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode, access, share));
        }

        public FileSystemStream New(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode, access, share, bufferSize));
        }

        public FileSystemStream New(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode, access, share, bufferSize, useAsync));
        }

        public FileSystemStream New(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, mode, access, share, bufferSize, options));
        }

        public FileSystemStream New(string path, FileStreamOptions options)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.New(path, options));
        }

        public FileSystemStream Wrap(FileStream fileStream)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.FileStream.Wrap(fileStream));
        }
        #endregion
    }
}
