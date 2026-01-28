using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLogic;
using System.IO;
using AssertM = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MSTestTests;

[TestClass]
public class FileProcessorTests
{
    [TestMethod]
    public void Write_Read_File_Works()
    {
        var fp = new FileProcessor();
        fp.WriteToFile("mstest.txt", "hello");

        AssertM.AreEqual("hello", fp.ReadFromFile("mstest.txt"));
        File.Delete("mstest.txt");
    }

    [TestMethod]
    public void Reading_NonExisting_File_Throws()
    {
        var fp = new FileProcessor();

        AssertM.ThrowsException<IOException>(() =>
        {
            fp.ReadFromFile("no_file.txt");
        });
    }
}
