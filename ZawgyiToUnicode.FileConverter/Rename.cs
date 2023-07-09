using System.IO;
using ZawgyiToUnicode.StringConverter;

namespace ZawgyiToUnicode.FileConverter;

public static class Rename
{
    public static Result ToUnicode(string zawgyiFilePath)
    {
        string zawgyiFileName = Path.GetFileName(zawgyiFilePath);
        string newFileName = Convert.ToUnicode(zawgyiFileName);
        var newPath = Path.Combine(Path.GetDirectoryName(zawgyiFilePath), newFileName);

        if (File.Exists(newPath))
        {
            string message = $"Failed to rename {zawgyiFileName} to {newFileName} because a file already exists at the location {newPath}.";
            return new Result(false, message);
        }

        File.Move(zawgyiFilePath, newPath);
        return new Result(true, $"Renamed {zawgyiFilePath} to {newPath}");
    }
}
