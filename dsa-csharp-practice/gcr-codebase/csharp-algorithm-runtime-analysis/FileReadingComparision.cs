using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class FileReadingComparision
{
    static void Main()
    {
        string filePath = "largefile.txt"; // assume large file exists (1MB / 100MB / 500MB)

        Console.WriteLine("File Size\tStreamReader Time\tFileStream Time");

        TestReading(filePath, "1MB");
        TestReading(filePath, "100MB");
        TestReading(filePath, "500MB");
    }

    static void TestReading(string filePath, string fileSizeLabel)
    {
        long streamReaderTime = ReadUsingStreamReader(filePath);
        long fileStreamTime = ReadUsingFileStream(filePath);

        Console.WriteLine($"{fileSizeLabel}\t\t{streamReaderTime} ms\t\t\t{fileStreamTime} ms");
    }

    // StreamReader: reads character by character (slower for large/binary files)
    static long ReadUsingStreamReader(string path)
    {
        Stopwatch sw = new Stopwatch();

        sw.Start();
        using (StreamReader reader = new StreamReader(path))
        {
            while (reader.Read() != -1) { }
        }
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }

    // FileStream: reads raw bytes (more efficient)
    static long ReadUsingFileStream(string path)
    {
        Stopwatch sw = new Stopwatch();
        byte[] buffer = new byte[4096];

        sw.Start();
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            while (fs.Read(buffer, 0, buffer.Length) > 0) { }
        }
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }
}
