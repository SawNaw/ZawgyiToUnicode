using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZawgyiToUnicode.FilenameConverter.Tests
{
    [TestFixture]
    public class TestHelperTests
    {
        [Test]
        public void CreateTestFile_CreatesFile_WithGivenZawgyiNames_InSpecifiedDirectory()
        {
            const string filename1 = "တပ္မက္မႈ";
            const string filename2 = "အေၾကာင္းခံေၾကာင့္";
            const string filename3 = "ျပင္းစြာ";
            const string filepath = @"C:\ZawgyiFiles\";

            FileCreator.CreateTestFile(filename1, filepath);
            FileCreator.CreateTestFile(filename2, filepath);
            FileCreator.CreateTestFile(filename3, filepath);

            Assert.That(File.Exists($"{filepath}\\{filename1}"), Is.True);
            Assert.That(File.Exists($"{filepath}\\{filename2}"), Is.True);
            Assert.That(File.Exists($"{filepath}\\{filename3}"), Is.True);

            // Clean up the created files and folder
            Directory.Delete($"{filepath}", true);
        }
    }
}
