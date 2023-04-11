using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Runtime.Versioning;
using System.Text;

namespace FileSystemRetry.FileSystem
{
    public class RetryFile : IFile
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryFile(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        public void AppendAllLines(string path, IEnumerable<string> contents)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllLines(path, contents));
        }

        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllLines(path, contents, encoding));
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllLinesAsync(path, contents, cancellationToken));
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllLinesAsync(path, contents, cancellationToken));
        }

        public void AppendAllText(string path, string? contents)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllText(path, contents));
        }

        public void AppendAllText(string path, string? contents, Encoding encoding)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllText(path, contents, encoding));
        }

        public Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllTextAsync(path, contents, cancellationToken));
        }

        public Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendAllTextAsync(path, contents, encoding, cancellationToken));
        }

        public StreamWriter AppendText(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.AppendText(path));
        }

        public void Copy(string sourceFileName, string destFileName)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Copy(sourceFileName, destFileName));
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Copy(sourceFileName, destFileName, overwrite));
        }

        public FileSystemStream Create(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Create(path));
        }

        public FileSystemStream Create(string path, int bufferSize)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Create(path, bufferSize));
        }

        public FileSystemStream Create(string path, int bufferSize, FileOptions options)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Create(path, bufferSize, options));
        }

        public IFileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.CreateSymbolicLink(path, pathToTarget));
        }

        public StreamWriter CreateText(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.CreateText(path));
        }

        [SupportedOSPlatform("windows")]
        public void Decrypt(string path)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Decrypt(path));
        }

        public void Delete(string path)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Delete(path));
        }

        [SupportedOSPlatform("windows")]
        public void Encrypt(string path)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Encrypt(path));
        }

        public bool Exists([NotNullWhen(true)] string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Exists(path));
        }

        public FileAttributes GetAttributes(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetAttributes(path));
        }

        public DateTime GetCreationTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetCreationTime(path));
        }

        public DateTime GetCreationTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetCreationTimeUtc(path));
        }

        public DateTime GetLastAccessTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetLastAccessTime(path));
        }

        public DateTime GetLastAccessTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetLastAccessTimeUtc(path));
        }

        public DateTime GetLastWriteTime(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetLastWriteTime(path));
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.GetLastWriteTimeUtc(path));
        }

        public void Move(string sourceFileName, string destFileName)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Move(sourceFileName, destFileName));
        }

        public void Move(string sourceFileName, string destFileName, bool overwrite)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Move(sourceFileName, destFileName, overwrite));
        }

        public FileSystemStream Open(string path, FileMode mode)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Open(path, mode));
        }

        public FileSystemStream Open(string path, FileMode mode, FileAccess access)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Open(path, mode, access));
        }

        public FileSystemStream Open(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Open(path, mode, access, share));
        }

        public FileSystemStream Open(string path, FileStreamOptions options)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Open(path, options));
        }

        public FileSystemStream OpenRead(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.OpenRead(path));
        }

        public StreamReader OpenText(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.OpenText(path));
        }

        public FileSystemStream OpenWrite(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.OpenWrite(path));
        }

        public byte[] ReadAllBytes(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllBytes(path));
        }

        public Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllBytesAsync(path, cancellationToken));

        }

        public string[] ReadAllLines(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllLines(path));

        }

        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllLines(path, encoding));

        }

        public Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllLinesAsync(path, cancellationToken));
        }

        public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllLinesAsync(path, encoding, cancellationToken));
        }

        public string ReadAllText(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllText(path));
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllText(path, encoding));
        }

        public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllTextAsync(path, cancellationToken));
        }

        public Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadAllTextAsync(path, encoding, cancellationToken));
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadLines(path));
        }

        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ReadLines(path, encoding));
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName));
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        }

        public IFileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.ResolveLinkTarget(linkPath, returnFinalTarget));
        }

        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetAttributes(path, fileAttributes));
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetCreationTime(path, creationTime));
        }

        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetCreationTimeUtc(path, creationTimeUtc));
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetLastAccessTime(path, lastAccessTime));
        }

        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetLastAccessTimeUtc(path, lastAccessTimeUtc));
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetLastWriteTime(path, lastWriteTime));
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.SetLastWriteTimeUtc(path, lastWriteTimeUtc));
        }

        public void WriteAllBytes(string path, byte[] bytes)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllBytes(path, bytes));
        }

        public Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllBytesAsync(path, bytes, cancellationToken));
        }

        public void WriteAllLines(string path, string[] contents)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLines(path, contents));
        }

        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLines(path, contents));
        }

        public void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLines(path, contents, encoding));
        }

        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLines(path, contents, encoding));
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLinesAsync(path, contents, cancellationToken));
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllLinesAsync(path, contents, encoding, cancellationToken));
        }

        public void WriteAllText(string path, string? contents)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllText(path, contents));
        }

        public void WriteAllText(string path, string? contents, Encoding encoding)
        {
            _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllText(path, contents, encoding));
        }

        public Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllTextAsync(path, contents, cancellationToken));
        }

        public Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.File.WriteAllTextAsync(path, contents, encoding, cancellationToken));
        }
        #endregion
    }
}
