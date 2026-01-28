using NUnit.Framework;
using CoreLogic;
using System.IO;
using AssertN = NUnit.Framework.Assert;

namespace NUnitTests;

[TestFixture]
public class FileProcessorTests
{
    [Test]
    public void Write_Read_File_Works()
    {
        var fp = new FileProcessor();
        fp.WriteToFile("nunit.txt", "hello");

        AssertN.AreEqual("hello", fp.ReadFromFile("nunit.txt"));
        File.Delete("nunit.txt");
    }
}
