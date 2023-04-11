using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Runtime.Versioning;
using System.Text;

namespace FileSystemRetry
{
    public class RetryFile : IFile
    {
        public IFileSystem FileSystem => _fileSystem;
        private IFileSystem _fileSystem { get; }

        private RetryPolicy _retryPolicy;
        private ILogger<IFileSystem>? _logger;

        private bool ShouldRetry(ref int retryCount, Exception ex)
        {
            var shouldRetryResult = true;

            _logger?.LogWarning($"Exception caught: [{ex}]. Retry [{retryCount}] out of [{_retryPolicy.NumberOfRetries}]");

            retryCount++;
            try
            {
                if (retryCount >= _retryPolicy.NumberOfRetries)
                {
                    shouldRetryResult = false;
                    return shouldRetryResult;
                }

                if (_retryPolicy.ExceptionsToRetry == null)
                {
                    shouldRetryResult = true;
                    return shouldRetryResult;
                }
                else
                {
                    shouldRetryResult = _retryPolicy.ExceptionsToRetry.Contains(ex.GetType());
                    return shouldRetryResult;
                }
            }
            finally
            {
                if (shouldRetryResult)
                {
                    Thread.Sleep(_retryPolicy.RetryFunction(retryCount));
                }
            }
        }

        public RetryFile(RetryPolicy retryPolicy, IFileSystem fileSystem, ILogger<IFileSystem>? logger)
        {
            _fileSystem = fileSystem;
            _retryPolicy = retryPolicy;
            _logger = logger;
        }

        public void HandleRetryFunction(Action toRetry)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    toRetry();
                    return;
                }
                catch (Exception ex)
                {
                    if (!ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public T HandleRetryFunction<T>(Func<T> toRetry)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    return toRetry();
                }
                catch (Exception ex)
                {
                    if (!ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public void AppendAllLines(string path, IEnumerable<string> contents)
        {
            HandleRetryFunction(() => _fileSystem.File.AppendAllLines(path, contents));
        }

        public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            HandleRetryFunction(() => _fileSystem.File.AppendAllLines(path, contents, encoding));
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.AppendAllLinesAsync(path, contents, cancellationToken));
        }

        public Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.AppendAllLinesAsync(path, contents, cancellationToken));
        }

        public void AppendAllText(string path, string? contents)
        {
            HandleRetryFunction(() => _fileSystem.File.AppendAllText(path, contents));
        }

        public void AppendAllText(string path, string? contents, Encoding encoding)
        {
            HandleRetryFunction(() => _fileSystem.File.AppendAllText(path, contents, encoding));
        }

        public Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.AppendAllTextAsync(path, contents, cancellationToken));
        }

        public Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.AppendAllTextAsync(path, contents, encoding, cancellationToken));
        }

        public StreamWriter AppendText(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.AppendText(path));
        }

        public void Copy(string sourceFileName, string destFileName)
        {
            HandleRetryFunction(() => _fileSystem.File.Copy(sourceFileName, destFileName));
        }

        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            HandleRetryFunction(() => _fileSystem.File.Copy(sourceFileName, destFileName, overwrite));
        }

        public FileSystemStream Create(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.Create(path));
        }

        public FileSystemStream Create(string path, int bufferSize)
        {
            return HandleRetryFunction(() => _fileSystem.File.Create(path, bufferSize));
        }

        public FileSystemStream Create(string path, int bufferSize, FileOptions options)
        {
            return HandleRetryFunction(() => _fileSystem.File.Create(path, bufferSize, options));
        }

        public IFileSystemInfo CreateSymbolicLink(string path, string pathToTarget)
        {
            return HandleRetryFunction(() => _fileSystem.File.CreateSymbolicLink(path, pathToTarget));
        }

        public StreamWriter CreateText(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.CreateText(path));
        }

        [SupportedOSPlatform("windows")]
        public void Decrypt(string path)
        {
            HandleRetryFunction(() => _fileSystem.File.Decrypt(path));
        }

        public void Delete(string path)
        {
            HandleRetryFunction(() => _fileSystem.File.Delete(path));
        }

        [SupportedOSPlatform("windows")]
        public void Encrypt(string path)
        {
            HandleRetryFunction(() => _fileSystem.File.Encrypt(path));
        }

        public bool Exists([NotNullWhen(true)] string? path)
        {
            return HandleRetryFunction(() => _fileSystem.File.Exists(path));
        }

        public FileAttributes GetAttributes(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetAttributes(path));
        }

        public DateTime GetCreationTime(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetCreationTime(path));
        }

        public DateTime GetCreationTimeUtc(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetCreationTimeUtc(path));
        }

        public DateTime GetLastAccessTime(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetLastAccessTime(path));
        }

        public DateTime GetLastAccessTimeUtc(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetLastAccessTimeUtc(path));
        }

        public DateTime GetLastWriteTime(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetLastWriteTime(path));
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.GetLastWriteTimeUtc(path));
        }

        public void Move(string sourceFileName, string destFileName)
        {
            HandleRetryFunction(() => _fileSystem.File.Move(sourceFileName, destFileName));
        }

        public void Move(string sourceFileName, string destFileName, bool overwrite)
        {
            HandleRetryFunction(() => _fileSystem.File.Move(sourceFileName, destFileName, overwrite));
        }

        public FileSystemStream Open(string path, FileMode mode)
        {
            return HandleRetryFunction(() => _fileSystem.File.Open(path, mode));
        }

        public FileSystemStream Open(string path, FileMode mode, FileAccess access)
        {
            return HandleRetryFunction(() => _fileSystem.File.Open(path, mode, access));
        }

        public FileSystemStream Open(string path, FileMode mode, FileAccess access, FileShare share)
        {
            return HandleRetryFunction(() => _fileSystem.File.Open(path, mode, access, share));
        }

        public FileSystemStream Open(string path, FileStreamOptions options)
        {
            return HandleRetryFunction(() => _fileSystem.File.Open(path, options));
        }

        public FileSystemStream OpenRead(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.OpenRead(path));
        }

        public StreamReader OpenText(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.OpenText(path));
        }

        public FileSystemStream OpenWrite(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.OpenWrite(path));
        }

        public byte[] ReadAllBytes(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllBytes(path));
        }

        public Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllBytesAsync(path, cancellationToken));

        }

        public string[] ReadAllLines(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllLines(path));

        }

        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllLines(path, encoding));

        }

        public Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllLinesAsync(path, cancellationToken));
        }

        public Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllLinesAsync(path, encoding, cancellationToken));
        }

        public string ReadAllText(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllText(path));
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllText(path, encoding));
        }

        public Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllTextAsync(path, cancellationToken));
        }

        public Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadAllTextAsync(path, encoding, cancellationToken));
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadLines(path));
        }

        public IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            return HandleRetryFunction(() => _fileSystem.File.ReadLines(path, encoding));
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName)
        {
            HandleRetryFunction(() => _fileSystem.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName));
        }

        public void Replace(string sourceFileName, string destinationFileName, string? destinationBackupFileName, bool ignoreMetadataErrors)
        {
            HandleRetryFunction(() => _fileSystem.File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
        }

        public IFileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
        {
            return HandleRetryFunction(() => _fileSystem.File.ResolveLinkTarget(linkPath, returnFinalTarget));
        }

        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            HandleRetryFunction(() => _fileSystem.File.SetAttributes(path, fileAttributes));
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            HandleRetryFunction(() => _fileSystem.File.SetCreationTime(path, creationTime));
        }

        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            HandleRetryFunction(() => _fileSystem.File.SetCreationTimeUtc(path, creationTimeUtc));
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            HandleRetryFunction(() => _fileSystem.File.SetLastAccessTime(path, lastAccessTime));
        }

        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            HandleRetryFunction(() => _fileSystem.File.SetLastAccessTimeUtc(path, lastAccessTimeUtc));
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            HandleRetryFunction(() => _fileSystem.File.SetLastWriteTime(path, lastWriteTime));
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            HandleRetryFunction(() => _fileSystem.File.SetLastWriteTimeUtc(path, lastWriteTimeUtc));
        }

        public void WriteAllBytes(string path, byte[] bytes)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllBytes(path, bytes));
        }

        public Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.WriteAllBytesAsync(path, bytes, cancellationToken));
        }

        public void WriteAllLines(string path, string[] contents)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllLines(path, contents));
        }

        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllLines(path, contents));
        }

        public void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllLines(path, contents, encoding));
        }

        public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllLines(path, contents, encoding));
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.WriteAllLinesAsync(path, contents, cancellationToken));
        }

        public Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.WriteAllLinesAsync(path, contents, encoding, cancellationToken));
        }

        public void WriteAllText(string path, string? contents)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllText(path, contents));
        }

        public void WriteAllText(string path, string? contents, Encoding encoding)
        {
            HandleRetryFunction(() => _fileSystem.File.WriteAllText(path, contents, encoding));
        }

        public Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.WriteAllTextAsync(path, contents, cancellationToken));
        }

        public Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
            return HandleRetryFunction(() => _fileSystem.File.WriteAllTextAsync(path, contents, encoding, cancellationToken));
        }
    }
}
