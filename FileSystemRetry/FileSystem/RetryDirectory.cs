using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryDirectory : IDirectory
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryDirectory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        public IDirectoryInfo CreateDirectory(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.CreateDirectory(path));
        }

        public IFileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.CreateSymbolicLink(path, pathToTarget));
        }

        public void Delete(string path)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.Delete(path));
        }

        public void Delete(string path, bool recursive)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.Delete(path, recursive));
        }

        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateDirectories(path));
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateDirectories(path, searchPattern));
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateDirectories(path, searchPattern, searchOption));
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateDirectories(path, searchPattern, enumerationOptions));
        }

        public IEnumerable<string> EnumerateFiles(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFiles(path));
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFiles(path, searchPattern));
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFiles(path, searchPattern, searchOption));
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFiles(path, searchPattern, enumerationOptions));
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFileSystemEntries(path));
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFileSystemEntries(path, searchPattern));
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFileSystemEntries(path, searchPattern, searchOption));
        }

        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.EnumerateFileSystemEntries(path, searchPattern, enumerationOptions));
        }

        public bool Exists([NotNullWhen(true)] string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.Exists(path));
        }

        public DateTime GetCreationTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetCreationTime(path));
        }

        public DateTime GetCreationTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetCreationTimeUtc(path));
        }

        public string GetCurrentDirectory()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetCurrentDirectory());
        }

        public string[] GetDirectories(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetDirectories(path));
        }

        public string[] GetDirectories(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetDirectories(path, searchPattern));
        }

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetDirectories(path, searchPattern, searchOption));
        }

        public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetDirectories(path, searchPattern, enumerationOptions));
        }

        public string GetDirectoryRoot(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetDirectoryRoot(path));
        }

        public string[] GetFiles(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFiles(path));
        }

        public string[] GetFiles(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFiles(path, searchPattern));
        }

        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFiles(path, searchPattern, searchOption));
        }

        public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFiles(path, searchPattern, enumerationOptions));
        }

        public string[] GetFileSystemEntries(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFileSystemEntries(path));
        }

        public string[] GetFileSystemEntries(string path, string searchPattern)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFileSystemEntries(path, searchPattern));
        }

        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFileSystemEntries(path, searchPattern, searchOption));
        }

        public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetFileSystemEntries(path, searchPattern, enumerationOptions));
        }

        public DateTime GetLastAccessTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetLastAccessTime(path));
        }

        public DateTime GetLastAccessTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetLastAccessTimeUtc(path));
        }

        public DateTime GetLastWriteTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetLastWriteTime(path));
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetLastWriteTimeUtc(path));
        }

        public string[] GetLogicalDrives()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetLogicalDrives());
        }

        public IDirectoryInfo? GetParent(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.GetParent(path));
        }

        public void Move(string sourceDirName, string destDirName)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.Move(sourceDirName, destDirName));
        }

        public IFileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.ResolveLinkTarget(linkPath, returnFinalTarget));
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetCreationTime(path, creationTime));
        }

        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetCreationTimeUtc(path, creationTimeUtc));
        }

        public void SetCurrentDirectory(string path)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetCurrentDirectory(path));
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetLastAccessTime(path, lastAccessTime));
        }

        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc));
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetLastWriteTime(path, lastWriteTime));
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc));
        }
        #endregion
    }
}
