using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryPath : IPath
    {
        public IFileSystem FileSystem => _innerFileSystem;

        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryPath(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        public char AltDirectorySeparatorChar => _innerFileSystem.Path.AltDirectorySeparatorChar;
        public char DirectorySeparatorChar => _innerFileSystem.Path.DirectorySeparatorChar;
        public char PathSeparator => _innerFileSystem.Path.PathSeparator;
        public char VolumeSeparatorChar => _innerFileSystem.Path.VolumeSeparatorChar;

        [return: NotNullIfNotNull("path")]
        public string? ChangeExtension(string? path, string? extension)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.ChangeExtension(path, extension));
        }

        public string Combine(string path1, string path2)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Combine(path1, path2));
        }

        public string Combine(string path1, string path2, string path3)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Combine(path1, path2, path3));
        }

        public string Combine(string path1, string path2, string path3, string path4)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Combine(path1, path2, path3, path4));
        }

        public string Combine(params string[] paths)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Combine(paths));
        }


        public bool EndsInDirectorySeparator(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.EndsInDirectorySeparator(path));
        }


        public string? GetDirectoryName(string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetDirectoryName(path));
        }


        [return: NotNullIfNotNull("path")]
        public string? GetExtension(string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetExtension(path));
        }


        [return: NotNullIfNotNull("path")]
        public string? GetFileName(string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetFileName(path));
        }


        [return: NotNullIfNotNull("path")]
        public string? GetFileNameWithoutExtension(string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetFileNameWithoutExtension(path));
        }

        public string GetFullPath(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetFullPath(path));
        }

        public string GetFullPath(string path, string basePath)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetFullPath(path, basePath));
        }

        public char[] GetInvalidFileNameChars()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetInvalidFileNameChars());
        }

        public char[] GetInvalidPathChars()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetInvalidPathChars());
        }


        public string? GetPathRoot(string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetPathRoot(path));
        }

        public string GetRandomFileName()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetRandomFileName());
        }

        public string GetRelativePath(string relativeTo, string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetRelativePath(relativeTo, path));
        }

        public string GetTempFileName()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetTempFileName());
        }

        public string GetTempPath()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.GetTempPath());
        }


        public bool HasExtension([NotNullWhen(true)] string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.HasExtension(path));
        }


        public bool IsPathFullyQualified(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.IsPathFullyQualified(path));
        }

        public bool IsPathRooted([NotNullWhen(true)] string? path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.IsPathRooted(path));
        }

        public string Join(string? path1, string? path2)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Join(path1, path2));
        }

        public string Join(string? path1, string? path2, string? path3)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Join(path1, path2, path3));
        }

        public string Join(params string?[] paths)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Join(paths));
        }


        public string Join(string? path1, string? path2, string? path3, string? path4)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.Join(path1, path2, path3, path4));
        }


        public string TrimEndingDirectorySeparator(string path)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.Path.TrimEndingDirectorySeparator(path));
        }

        #region SpecialTreatmentFunctions
        public bool EndsInDirectorySeparator(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.EndsInDirectorySeparator(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.GetDirectoryName(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.GetExtension(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.GetFileName(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.GetFileNameWithoutExtension(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.GetPathRoot(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool HasExtension(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.HasExtension(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool IsPathFullyQualified(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.IsPathFullyQualified(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool IsPathRooted(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.IsPathRooted(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.Join(path1, path2);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.Join(path1, path2, path3);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }
        public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.Join(path1, path2, path3, path4);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public ReadOnlySpan<char> TrimEndingDirectorySeparator(ReadOnlySpan<char> path)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.TrimEndingDirectorySeparator(path);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.TryJoin(path1, path2, destination, out charsWritten);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }

        public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten)
        {
            int retryCount = 0;

            while (true)
            {
                try
                {
                    return _innerFileSystem.Path.TryJoin(path1, path2, path3, destination, out charsWritten);
                }
                catch (Exception ex)
                {
                    if (!_retryHandler.ShouldRetry(ref retryCount, ex))
                        throw;
                }
            }
        }
        #endregion
        #endregion
    }
}
