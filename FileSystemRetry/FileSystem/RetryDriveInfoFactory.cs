using FileSystemRetry.Handler;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;

namespace FileSystemRetry.FileSystem
{
    public class RetryDriveInfoFactory : IDriveInfoFactory
    {
        public IFileSystem FileSystem => _innerFileSystem;
        private IFileSystem _innerFileSystem { get; }

        private IRetryHandler _retryHandler;

        public RetryDriveInfoFactory(IRetryHandler retryHandler, IFileSystem innerFileSystem)
        {
            _innerFileSystem = innerFileSystem;
            _retryHandler = retryHandler;
        }

        #region OverrideFunctions
        [Obsolete("Use `IDriveInfoFactory.New(string)` instead")]
        public IDriveInfo FromDriveName(string driveName)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DriveInfo.FromDriveName(driveName));
        }

        public IDriveInfo[] GetDrives()
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DriveInfo.GetDrives());
        }

        public IDriveInfo New(string driveName)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DriveInfo.New(driveName));
        }

        [return: NotNullIfNotNull("driveInfo")]
        public IDriveInfo? Wrap(DriveInfo? driveInfo)
        {
            return _retryHandler.HandleRetryFunction(() => _innerFileSystem.DriveInfo.Wrap(driveInfo));
        }
        #endregion
    }
}
