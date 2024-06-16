using NUnit.Framework;
namespace ZawgyiToUnicode.FileConverter.UnitTests.RenameTests;

public class FolderAndContentsToUnicodeTests
{
    [Test]
    public void FolderNotFound_ReturnsFailResult()
    {

        string nonExistentPath = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid().ToString());
        var result = Rename.FolderAndContentsToUnicode(nonExistentPath);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.False);
            string expectedMessage = Rename.CouldNotFindFolderMessage(nonExistentPath);
            Assert.That(result.Message, Is.EqualTo(expectedMessage));
        });
    }

    [Test]
    public void FolderFound_ReturnsSuccessResult()
    {
        string folderToCreate = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(folderToCreate);

        var result = Rename.FolderAndContentsToUnicode(folderToCreate);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.True);
        });

        Directory.Delete(folderToCreate);
    }
}
