using NUnit.Framework;

namespace ZawgyiToUnicode.FileConverter.UnitTests.RenameTests;

public class ToUnicodeTests
{
    [Test]
    public void ToUnicode_RenamesFile_ToUnicode()
    {
        string testDirectory = Path.Combine(Environment.CurrentDirectory, $"UnitTestsTemporary-{Guid.NewGuid()}");
        const string zawgyiFileName = "သီဟိုဠ္မွ ဉာဏ္ႀကီးရွင္သည္ အာယုဝၯနေဆးၫႊန္းစာကိုဇလြန္ေဈးေဘး ဗာဒံပင္ထက္ အဓိ႒ာန္လ်က္ ဂဃနဏဖတ္ခဲ့သည္.somefile";
        const string expectedFileName = "သီဟိုဠ်မှ ဉာဏ်ကြီးရှင်သည် အာယုဝဍ္ဎနဆေးညွှန်းစာကိုဇလွန်ဈေးဘေး ဗာဒံပင်ထက် အဓိဋ္ဌာန်လျက် ဂဃနဏဖတ်ခဲ့သည်.somefile";

        CreateTestFileInTemporaryDirectory(zawgyiFileName, testDirectory);

        var zawgyiFilePath = Path.Combine(testDirectory, zawgyiFileName);

        var result = Rename.ToUnicode(zawgyiFilePath);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(Directory.GetFiles(testDirectory).Length == 1);
            Assert.That(Directory.GetFiles(testDirectory)
                                 .Single(),
                                 Is.EqualTo(Path.Combine(testDirectory, expectedFileName)));
        });

        Directory.Delete(testDirectory, true);

    }

    [Test]
    public void ToUnicode_DoesNotOverwriteExistingDestinationFile()
    {
        string testDirectory = Path.Combine(Environment.CurrentDirectory, $"UnitTestsTemporary-{Guid.NewGuid()}");
        const string fileName = "Somefile.extension";

        CreateTestFileInTemporaryDirectory(fileName, testDirectory);

        var zawgyiFilePath = Path.Combine(testDirectory, fileName);

        var result = Rename.ToUnicode(zawgyiFilePath);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(Directory.GetFiles(testDirectory).Length == 1);
            Assert.That(Directory.GetFiles(testDirectory)
                                 .Single(),
                                 Is.EqualTo(Path.Combine(testDirectory, fileName)));
        });

        Directory.Delete(testDirectory, true);

    }

    private static void CreateTestFileInTemporaryDirectory(string fileName, string directoryPath)
    {
        Directory.CreateDirectory(directoryPath);
        var fullFilePath = Path.Combine(directoryPath, fileName);
        File.Create(fullFilePath).Close();
    }
}
