using System;
using System.IO;

class Program
{
    static void Main()
    {
        string sourceImage = "original.jpg";
        string newImage = "copy.jpg";

        if (!File.Exists(sourceImage))
        {
            Console.WriteLine("Source image file does not exist.");
            return;
        }

        // Step 1: Read image into byte array
        byte[] imageBytes = ReadImageAsByteArray(sourceImage);

        // Step 2: Write byte array to new image file
        WriteByteArrayToImage(imageBytes, newImage);

        // Step 3: Verify both images are identical
        bool isSame = CompareFiles(sourceImage, newImage);

        Console.WriteLine(isSame
            ? "Image copied successfully. Files are identical."
            : "Image copy failed. Files are different.");
    }

    // ================= READ IMAGE =================
    static byte[] ReadImageAsByteArray(string path)
    {
        byte[] bytes;

        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (MemoryStream memoryStream = new MemoryStream())
        {
            fileStream.CopyTo(memoryStream);
            bytes = memoryStream.ToArray();
        }

        return bytes;
    }

    // ================= WRITE IMAGE =================
    static void WriteByteArrayToImage(byte[] bytes, string path)
    {
        using (MemoryStream memoryStream = new MemoryStream(bytes))
        using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            memoryStream.WriteTo(fileStream);
        }
    }

    // ================= COMPARE FILES =================
    static bool CompareFiles(string file1, string file2)
    {
        byte[] first = File.ReadAllBytes(file1);
        byte[] second = File.ReadAllBytes(file2);

        if (first.Length != second.Length)
            return false;

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
                return false;
        }

        return true;
    }
}
