using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceFile = "largefile.dat";
        string normalCopy = "normal_copy.dat";
        string bufferedCopy = "buffered_copy.dat";

        if (!File.Exists(sourceFile))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        Console.WriteLine("Copying file using normal FileStream...");
        long normalTime = CopyUsingFileStream(sourceFile, normalCopy);

        Console.WriteLine("\nCopying file using BufferedStream...");
        long bufferedTime = CopyUsingBufferedStream(sourceFile, bufferedCopy);

        Console.WriteLine("\n--- Performance Comparison ---");
        Console.WriteLine($"Normal FileStream Time  : {normalTime} ms");
        Console.WriteLine($"BufferedStream Time    : {bufferedTime} ms");
    }

    // ================= NORMAL FILESTREAM COPY =================
    static long CopyUsingFileStream(string source, string destination)
    {
        Stopwatch stopwatch = new Stopwatch();
        byte[] buffer = new byte[4096]; // 4 KB buffer

        stopwatch.Start();

        using (FileStream sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (FileStream destStream = new FileStream(destination, FileMode.Create, FileAccess.Write))
        {
            int bytesRead;
            while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                destStream.Write(buffer, 0, bytesRead);
            }
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // ================= BUFFERED STREAM COPY =================
    static long CopyUsingBufferedStream(string source, string destination)
    {
        Stopwatch stopwatch = new Stopwatch();
        byte[] buffer = new byte[4096]; // 4 KB buffer

        stopwatch.Start();

        using (FileStream sourceFileStream = new FileStream(source, FileMode.Open, FileAccess.Read))
        using (FileStream destFileStream = new FileStream(destination, FileMode.Create, FileAccess.Write))
        using (BufferedStream bufferedSource = new BufferedStream(sourceFileStream))
        using (BufferedStream bufferedDest = new BufferedStream(destFileStream))
        {
            int bytesRead;
            while ((bytesRead = bufferedSource.Read(buffer, 0, buffer.Length)) > 0)
            {
                bufferedDest.Write(buffer, 0, bytesRead);
            }
        }

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}
