using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileSystem
{
    public class Program
    {
        static FileSystemWatcher watcher;
        static void Main(string[] args)
        {
            watcher = new FileSystemWatcher();
            watcher.Path = @"C:\watched_folder"; // Change this to your desired folder
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            watcher.Created += OnChanged;
            watcher.Changed += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            Console.Read();
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Invoke is needed to update UI from a different thread
            //this.Invoke((MethodInvoker)delegate
            //{
            //    listBox.Items.Add($"{e.ChangeType}: {e.FullPath}");
            //});

            Console.WriteLine($"{e.ChangeType}:{e.FullPath}");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            //this.Invoke((MethodInvoker)delegate
            //{
            //    listBox.Items.Add($"Renamed: {e.OldFullPath} -> {e.FullPath}");
            //});
            Console.WriteLine($"{e.ChangeType}:{e.FullPath}");
        }

    }


}
