using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class FileSearchInDirectory
    {
        public static HashSet<string> Search(string fileName, string dirName)
        {
            Queue<string> dirsToSearch = new Queue<string>();
            HashSet<string> foundFiles = new HashSet<string>();
            dirsToSearch.Enqueue(dirName);

            while (dirsToSearch.Count != 0)
            {
                string currentlySearchedDir = dirsToSearch.Dequeue();
                DirectoryInfo directoryInfo = new DirectoryInfo(currentlySearchedDir);
                DirectoryInfo[] directories;
                try
                {
                    directories = directoryInfo.GetDirectories();
                    AddDirectoriesToQueue(directories, ref dirsToSearch);
                    var files = directoryInfo.GetFiles();
                    SearchForGivenFile(files, fileName, ref foundFiles);
                } catch(UnauthorizedAccessException e)
                {
                    Console.WriteLine(e);
                }
                catch(DirectoryNotFoundException e)
                {
                    Console.WriteLine(e);
                }
                catch(Exception e) {
                    Console.WriteLine(e);
                }
            }

            return foundFiles;
        }

        static void AddDirectoriesToQueue(DirectoryInfo[] directories, ref Queue<string> dirsToSearch)
        {
            foreach (var dir in directories)
            {
                dirsToSearch.Enqueue(dir.FullName);
            }
        }

        static void SearchForGivenFile(FileInfo[] files, string searchedFileName, ref HashSet<string> foundFiles)
        {
            foreach (var file in files)
            {
                if (file.Name.Equals(searchedFileName))
                {
                    foundFiles.Add(file.FullName);
                }
            }
        }
    }
}
