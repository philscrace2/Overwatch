using System;
using System.IO;

namespace FileSystem
{
    public interface IFileystem
    {
        string GetTextFiles();
        bool CopyFileTo(string from, string to);

    }
}
