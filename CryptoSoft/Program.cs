using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args) //passage en parametre 
    {
        string filePath, encryptedFolderPath, encryptionKey;

        // Check if there are enough arguments.
        if (args.Length >= 3)
        {
            filePath = args[0];
            encryptedFolderPath = args[1];
            encryptionKey = args[2];
        }
        else
        {
            Console.WriteLine("Usage: CryptoSoft.exe <input_path> <output_path> <encryptionKey>");
            return;
        }

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The specified file doesn't exist.");
            return;
        }

        //Run Timer
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        // Read the contents of the file
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Convert the content of the file to binary
        StringBuilder fileBinary = new StringBuilder();
        foreach (byte b in fileBytes)
        {
            fileBinary.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }

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

        // stop timer
        stopWatch.Stop();

        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}H:{1:00}M:{2:00}S.{3:00}MS",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds );
        Console.WriteLine("RunTime " + elapsedTime);
    }
}
