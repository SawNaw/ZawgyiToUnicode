using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using ZawgyiToUnicode.Core;

namespace ZawgyiToUnicode.FilenameConverter.Tests
{
    [TestFixture]
    public class FilenameConverterTests
    {
        private string inputFilePath = $"{Directory.GetCurrentDirectory()}\\TestFiles\\";
        private string outputFilePath = $"{Directory.GetCurrentDirectory()}\\TestFiles\\Unicode_File_Names\\";

        private static List<string> zawgyiFilenames = new List<string> {
                "တပ္မက္မႈ",
                "အေၾကာင္းခံေၾကာင့္",
                "ျပင္းစြာ" };

        private static List<string> expectedConvertedFilenames = new List<string> {
                ZawgyiToUnicode.Core.Convert.ToUnicode(zawgyiFilenames[0]),
                ZawgyiToUnicode.Core.Convert.ToUnicode(zawgyiFilenames[1]),
                ZawgyiToUnicode.Core.Convert.ToUnicode(zawgyiFilenames[2])
            };

        [Test]
        public void DefaultConstructor_SetsInputDirectory_ToExpected()
        {
            var fc = new FilenameConverter();
            var expected = $"{Directory.GetCurrentDirectory()}";
            Assert.That(fc.InputDirectory, Is.EqualTo(expected));
        }

        [Test]
        public void DefaultConstructor_SetsOutputDirectory_ToExpected()
        {
            var fc = new FilenameConverter();
            var expected = $"{Directory.GetCurrentDirectory()}\\Unicode_File_Names";
            Assert.That(fc.OutputDirectory, Is.EqualTo(expected));
        }

        [Test]
        public void ConvertFilenameToUnicode_ConvertsZawgyiFilenames_ToUnicode()
        {
            // Arrange
            CreateTestFiles(zawgyiFilenames, inputFilePath);

            // Act
            FilenameConverter fc = new FilenameConverter(inputFilePath);
            fc.ConvertAllFilenamesToUnicode(false);

            // Assert
            foreach (var file in expectedConvertedFilenames)
            {
                Assert.That(File.Exists($"{outputFilePath}\\{file}"), Is.True);
            }

            // Clean up
            DeleteTestFiles(zawgyiFilenames, inputFilePath);
        }

        [Test]
        public void ConvertFilenameToUnicode_DoesNotAlter_ExistingZawgyiFiles()
        {
            // Arrange
            CreateTestFiles(zawgyiFilenames, inputFilePath);

            // Act
            FilenameConverter fc = new FilenameConverter(inputFilePath);
            fc.ConvertAllFilenamesToUnicode(false);

            // Assert
            foreach (var file in zawgyiFilenames)
            {
                Assert.That(File.Exists($"{inputFilePath}\\{file}"), Is.True);
            }

            // Clean up
            DeleteTestFiles(zawgyiFilenames, inputFilePath);
        }

        [Test]
        public void Conversion_WorksInFolders_AndSubFolders()
        {
            // Arrange
            string testFilesRelativePath = "Test3AX49";
            CreateZawgyiTestFileStructure(testFilesRelativePath);

            FilenameConverter cv = new FilenameConverter($"{Directory.GetCurrentDirectory()}\\{testFilesRelativePath}");

            cv.ConvertAllFilenamesToUnicode(true);

            Assert.That(File.Exists($"{Directory.GetCurrentDirectory()}\\{testFilesRelativePath}\\အမိုက်စားသီချင်းများ\\ပထမစုစည်းမှု\\Unicode_File_Names\\ဘာညာကွိကွ.mp3"), Is.True);
            Assert.That(File.Exists($"{Directory.GetCurrentDirectory()}\\{testFilesRelativePath}\\အမိုက်စားသီချင်းများ\\ဒုတိယစုစည်းမှု\\Unicode_File_Names\\ဘာညာကွိကွ.mp3"), Is.True);
            Assert.That(File.Exists($"{Directory.GetCurrentDirectory()}\\{testFilesRelativePath}\\အမိုက်စားသီချင်းများ\\ဒုတိယစုစည်းမှု\\Unicode_File_Names\\ဗာဒံပင်ထက် အဓိဋ္ဌာန်လျက်.mp3"), Is.True);

            // Clean up test files
            Directory.Delete($"{Directory.GetCurrentDirectory()}\\{testFilesRelativePath}");
        }

        private static void CreateTestFiles(List<string> filenames, string filepath)
        {
            foreach (var file in filenames)
            {
                FileCreator.CreateTestFile(file, filepath);
            }
        }

        private static void DeleteTestFiles(List<string> filenames, string filepath)
        {
            if (Directory.Exists(filepath))
            {
                Directory.Delete(filepath, true);
            }
        }
        private static void CreateZawgyiTestFileStructure(string relativePath)
        {
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{relativePath}"))
            {
                Directory.Delete($"{Directory.GetCurrentDirectory()}\\{relativePath}", true);
            }

            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အလြန္ေကာင္းေသာ သီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\");
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\");
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\");

            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အလြန္ေကာင္းေသာ သီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\ဘာညာကြိကြ.mp3").Close();
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\ဘာညာကြိကြ.mp3").Close();
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\ဘာညာကြိကြ.mp3").Close();
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\ဗာဒံပင္ထက္ အဓိ႒ာန္လ်က္.mp3").Close();

        }
    }
}
