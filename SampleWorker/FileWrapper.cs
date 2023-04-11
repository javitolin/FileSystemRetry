using System.IO.Abstractions;

namespace SampleWorker
{
    public class FileWrapper
    {
        private readonly IFileSystem _fileSystem;

        public FileWrapper(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public FileSystemStream OpenFileRead(string filename)
        {
            return _fileSystem.File.OpenRead(filename);
        }
        public bool FileExists(string filename)
        {
            return _fileSystem.File.Exists(filename);
        }
    }
}
