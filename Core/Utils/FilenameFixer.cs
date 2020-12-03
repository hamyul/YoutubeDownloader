using System;
using System.IO;

namespace YoutubeDownloader.Core.Utils
{
    public class FilenameFixer
    {
        private string _filename;
        private string _path;

        public FilenameFixer(string filename, string path)
        {
            _filename = filename;
            _path = path;

            Validate();
        }

        public string GetFilename()
        {
            RemoveInvalidPathChars();
            RemoveInvalidFilenameChars();
            FixExtension();
            
            return Path.Combine(_path, _filename);
        }

        protected void FixExtension()
        {
            _filename = Path.ChangeExtension(_filename.Replace(" - YouTube", string.Empty), ".mp4");
        }

        protected void RemoveInvalidFilenameChars()
        {
            foreach (char c in new string(Path.GetInvalidFileNameChars()))
            {
                _filename = _filename.Replace(c.ToString(), string.Empty);
            }
        }

        protected void RemoveInvalidPathChars()
        {
            foreach (char c in new string(Path.GetInvalidPathChars()))
            {
                _path = _path.Replace(c.ToString(), string.Empty);
            }
        }

        protected void Validate()
        {
            if (string.IsNullOrEmpty(_filename))
                throw new ArgumentNullException("Null or empty filename.");

            if (string.IsNullOrEmpty(_path))
                throw new ArgumentNullException("Null or empty path.");
        }
    }
}