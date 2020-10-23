using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToDifferentEncoding
{
    class FileHandler
    {
        string FilepathToRead { get; } = @"..\..\.gitignore";
        string FilePathToWrite { get; } = @"..\..\gitignore_utf7.txt";

        string ReadFromFile()
        {
            StreamReader streamReader = File.OpenText(FilepathToRead);
            string fileContent = streamReader.ReadToEnd();
            streamReader.Close();
            return fileContent;
        }

        public void WriteToFile()
        {
            var streamWriterUtf7 = new StreamWriter(FilePathToWrite, false, Encoding.UTF7);
            streamWriterUtf7.WriteLine(ReadFromFile());
            streamWriterUtf7.Close();
        }
    }
}
