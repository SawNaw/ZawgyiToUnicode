using NUnit.Framework;
using System;
using System.IO;

namespace ZawgyiToUnicode.FilenameConverter.Tests
{
    [TestFixture]
    public class FilenameConverterTests
    {
        [Test]
        public void CreateZawgyiFile_CreatesFile_WithGivenZawgyiNames_InSpecifiedDirectory()
        {
            const string filename1 = "တပ္မက္မႈ";
            const string filename2 = "အေၾကာင္းခံေၾကာင့္";
            const string filename3 = "ျပင္းစြာ";
            const string filepath = @"C:\ZawgyiFiles\";

            TestHelper.CreateFile(filename1, filepath);
            TestHelper.CreateFile(filename2, filepath);
            TestHelper.CreateFile(filename3, filepath);

            Assert.That(File.Exists($"{filepath}\\{filename1}"), Is.True);
            Assert.That(File.Exists($"{filepath}\\{filename2}"), Is.True);
            Assert.That(File.Exists($"{filepath}\\{filename3}"), Is.True);
        }
    }
}
