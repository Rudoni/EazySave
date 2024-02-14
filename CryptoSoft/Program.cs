using System;
using System.IO;
using System.Text;

class Program
{
    static void Main() //passage en parametre 
    {
        // Path of the file to encrypt
        Console.Write("Enter the path of the file to encrypt: ");
        string filePath = Console.ReadLine();

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The specified file doesn't exist.");
            return; //-1
        }

        // Read the contents of the file
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Convert the content of the file to binary
        StringBuilder fileBinary = new StringBuilder();
        foreach (byte b in fileBytes)
        {
            fileBinary.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }

        // Ask the user for the encryption key
        Console.Write("Enter the encryption key: ");
        string encryptionKey = Console.ReadLine();

        // Convert the key to binary
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
        StringBuilder keyBinary = new StringBuilder();
        foreach (byte b in keyBytes)
        {
            keyBinary.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }

        // Perform the XOR encryption
        StringBuilder encryptedBinary = new StringBuilder();
        for (int i = 0; i < fileBinary.Length; i++)
        {
            int fileBit = int.Parse(fileBinary[i].ToString());
            int keyBit = int.Parse(keyBinary[i % keyBinary.Length].ToString());
            int encryptedBit = fileBit ^ keyBit;
            encryptedBinary.Append(encryptedBit);
        }

        // Convert the binary result to bytes
        byte[] encryptedBytes = new byte[encryptedBinary.Length / 8];
        for (int i = 0; i < encryptedBinary.Length; i += 8)
        {
            encryptedBytes[i / 8] = Convert.ToByte(encryptedBinary.ToString().Substring(i, 8), 2);
        }

        //  Path to the directory where to save the encrypted file
        Console.Write("Enter the path to the directory where to save the encrypted file: ");
        string encryptedFolderPath = Console.ReadLine();

        // Create the directory if it doesn't exist
        if (!Directory.Exists(encryptedFolderPath))
        {
            Directory.CreateDirectory(encryptedFolderPath);
        }

        // Full path where to save the encrypted file.
        string encryptedFilePath = Path.Combine(encryptedFolderPath, Path.GetFileNameWithoutExtension(filePath) + "_encrypted" + Path.GetExtension(filePath));

        // Save the encrypted file
        File.WriteAllBytes(encryptedFilePath, encryptedBytes);

        Console.WriteLine("The file has been successfully encrypted.");
        Console.WriteLine($"Encrypted file saved as: {encryptedFilePath}");
    }
}
