using System.IO;
using System.Collections.Generic;
using Foxtale.Entities.UI.Controls;
using System.Linq;

namespace Foxtale.Core.IO;

public static class Operations
{
    public static readonly string[] ImageTypes = ["png", "bmp", "jpg"];
    public static readonly string[] TextTypes = ["txt", "rtf", "md", "log"];

    /// <summary>
    /// Get all files in a directory (and it's subdirectories, and so on)
    /// </summary>
    /// <param name="path">The path to start search from</param>
    /// <returns>A list containing paths to all files in path</returns>
    public static List<string> FindAllFiles(string path)
    {
        string[] subdirs = Directory.GetDirectories(path);
        List<string> files = new(Directory.GetFiles(path));

        foreach (string dir in subdirs)
        {
            files.AddRange(FindAllFiles(dir));
        }

        return files;
    }

    /// <summary>
    /// Replace path separators with appropriate ones for current OS
    /// </summary>
    /// <param name="path">Path to filter</param>
    /// <returns>path with all likely path separators replace with Path.DirectorySeparatorChar</returns>
    public static string FilterPathSeparators(string path)
    {
        return path.Replace('/', Path.DirectorySeparatorChar)
            .Replace('\\', Path.DirectorySeparatorChar);
    }

    /// <summary>
    /// Get type (image, text, binary) of file
    /// </summary>
    /// <param name="path">Path to file</param>
    /// <returns>Most appropriate FileType for file at Path</returns>
    /// TODO: also check for font types!
    public static FileType GetFileType(string path)
    {
        string ext = new FileInfo(path).Extension;
        if (ImageTypes.Contains(ext)) return FileType.Image;
        else if (TextTypes.Contains(ext)) return FileType.Text;
        return FileType.Binary;
    }
}
