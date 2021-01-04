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

        internal static void CreateZawgyiTestFileStructure(string relativePath)
        {
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{relativePath}"))
            {
                Directory.Delete($"{Directory.GetCurrentDirectory()}\\{relativePath}", true);
            }

            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အလြန္ေကာင္းေသာ သီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\");
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\");
            Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\");
           
            FileStream fs = File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အလြန္ေကာင္းေသာ သီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\ဘာညာကြိကြ.mp3");
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ပထမစုစည္းမႈ\\ဘာညာကြိကြ.mp3");
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\ဘာညာကြိကြ.mp3");
            File.Create($"{Directory.GetCurrentDirectory()}\\{relativePath}\\အမိုက္စားသီခ်င္းမ်ား\\ဒုတိယစုစည္းမႈ\\ဗာဒံပင္ထက္ အဓိ႒ာန္လ်က္.mp3");


        }
    }
}
