using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    // 16-byte key and IV (AES-128)
    static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890ABCDEF");
    static readonly byte[] IV  = Encoding.UTF8.GetBytes("ABCDEF1234567890");

    static void Main()
    {
        WriteEncryptedCsv("employees_secure.csv");
        ReadDecryptedCsv("employees_secure.csv");
    }

    // ================= ENCRYPTION =================

    static string Encrypt(string plainText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform encryptor = aes.CreateEncryptor();

        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

        return Convert.ToBase64String(encryptedBytes);
    }

    static string Decrypt(string cipherText)
    {
        using Aes aes = Aes.Create();
        aes.Key = Key;
        aes.IV = IV;

        ICryptoTransform decryptor = aes.CreateDecryptor();

        byte[] encryptedBytes = Convert.FromBase64String(cipherText);
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }

    // ================= WRITE CSV =================

    static void WriteEncryptedCsv(string filePath)
    {
        using StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("ID,Name,Email,Salary");

        writer.WriteLine($"1,Alice,{Encrypt("alice@gmail.com")},{Encrypt("50000")}");
        writer.WriteLine($"2,Bob,{Encrypt("bob@yahoo.com")},{Encrypt("65000")}");

        Console.WriteLine("Encrypted CSV written.");
    }

    // ================= READ CSV =================

    static void ReadDecryptedCsv(string filePath)
    {
        Console.WriteLine("\nDecrypted Records:");
        Console.WriteLine("------------------");

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            string[] data = lines[i].Split(',');

            string email = Decrypt(data[2]);
            string salary = Decrypt(data[3]);

            Console.WriteLine(
                $"ID: {data[0]}, Name: {data[1]}, Email: {email}, Salary: {salary}"
            );
        }
    }
}
