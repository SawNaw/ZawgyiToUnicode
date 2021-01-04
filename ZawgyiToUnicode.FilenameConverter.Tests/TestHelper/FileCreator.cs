using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ZawgyiToUnicode.FilenameConverter.Tests
{
    internal static class FileCreator
    {
        internal static void CreateTestFile(string filename, string filepath)
        {
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            var fs = File.Create($"{filepath}\\{filename}");
            fs.Close();
        }
    }
}
