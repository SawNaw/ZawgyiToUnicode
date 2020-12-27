using System;
using System.IO;
using ZawgyiToUnicode.TextConverter;

namespace ZawgyiToUnicode.FilenameConverter
{
    public class FilenameConverter
    {
        /// <summary>
        /// Gets the directory where this <see cref="FilenameConverter"/> will operate.
        /// </summary>
        public string WorkingDirectory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilenameConverter"/> class.
        /// </summary>
        /// <param name="workingDirectory">The directory where this <see cref="FilenameConverter"/> will operate.</param>
        public FilenameConverter(string workingDirectory)
        {
            this.WorkingDirectory = workingDirectory;
        }

        /// <summary>
        /// Converts all the filenames in the working directory from Zawgyi to Unicode.
        /// </summary>
        public void ConvertAllFilenamesToUnicode()
        {
            var directoryInfo = new DirectoryInfo(this.WorkingDirectory);
            string outputDirectory = $"{this.WorkingDirectory}_Unicode_File_Names";
            Directory.CreateDirectory(outputDirectory);

            var allFiles = directoryInfo.GetFiles();

            foreach (var zawgyiFile in allFiles)
            {
                string convertedFilename = Converter.ToUnicode(zawgyiFile.Name);

                if (zawgyiFile.Name != convertedFilename)
                {
                    continue;
                }

                if (File.Exists($"{outputDirectory}\\{convertedFilename}"))
                {
                    continue;
                }

                File.Move(zawgyiFile.FullName, $"{outputDirectory}\\{convertedFilename}");
            }
        }
    }
}
