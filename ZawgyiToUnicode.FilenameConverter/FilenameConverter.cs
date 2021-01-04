using System;
using System.IO;
using ZawgyiToUnicode.Core;

namespace ZawgyiToUnicode.FilenameConverter
{
    public class FilenameConverter
    {
        /// <summary>
        /// Gets the directory where this <see cref="FilenameConverter"/> will take input files.
        /// </summary>
        public string InputDirectory { get; private set; }

        /// <summary>
        /// Gets the directory where this <see cref="FilenameConverter"/> will output files.
        /// </summary>
        public string OutputDirectory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilenameConverter"/> class.
        /// </summary>
        /// <param name="inputDirectory">The directory that contains input files.</param>
        public FilenameConverter()
        {
            this.InputDirectory = Directory.GetCurrentDirectory();
            this.OutputDirectory = $"{this.InputDirectory}\\Unicode_File_Names";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilenameConverter"/> class.
        /// </summary>
        /// <param name="inputDirectory">The directory that contains input files.</param>
        public FilenameConverter(string inputDirectory)
        {
            this.InputDirectory = inputDirectory;
            this.OutputDirectory = $"{this.InputDirectory}\\Unicode_File_Names";
        }

        /// <summary>
        /// Converts all the filenames in the working directory from Zawgyi to Unicode.
        /// </summary>
        public void ConvertAllFilenamesToUnicode()
        {
            if (this.InputDirectory == this.OutputDirectory)
            {
                throw new InvalidOperationException("The output directory cannot be the same as the input directory.");
            }

            var inputDir = new DirectoryInfo(this.InputDirectory);
            Directory.CreateDirectory(this.OutputDirectory);

            var allFiles = inputDir.GetFiles();

            foreach (var zawgyiFile in allFiles)
            {
                string convertedFilename = ZawgyiToUnicode.Core.Convert.ToUnicode(zawgyiFile.Name);

                if (zawgyiFile.Name != convertedFilename && !File.Exists($"{this.OutputDirectory}\\{convertedFilename}"))
                {
                    File.Copy(zawgyiFile.FullName, $"{this.OutputDirectory}\\{convertedFilename}");
                }
            }
        }
    }
}
