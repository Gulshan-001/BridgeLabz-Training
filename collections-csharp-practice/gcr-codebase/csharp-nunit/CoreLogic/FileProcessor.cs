namespace CoreLogic;

public class FileProcessor
{
    public void WriteToFile(string file, string content)
    {
        File.WriteAllText(file, content);
    }

    public string ReadFromFile(string file)
    {
        if (!File.Exists(file))
            throw new IOException("File not found");

        return File.ReadAllText(file);
    }
}
