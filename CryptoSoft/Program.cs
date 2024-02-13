using System;
using System.IO;
using System.Text;

class Program
{
    static void Main() //passage en parametre 
    {
        // Path of the file to encrypt
        Console.Write("Entrez le chemin du fichier à crypter : ");
        string filePath = Console.ReadLine();

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Le fichier spécifié n'existe pas.");
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
        Console.Write("Entrez la clé de chiffrement : ");
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

        // Save the encrypted file
        Console.Write("Entrez le chemin complet où enregistrer le fichier crypté : ");
        string encryptedFilePath = Console.ReadLine();

        // Ensure that the directory exists
        string directoryPath = Path.GetDirectoryName(encryptedFilePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Save the encrypted file
        File.WriteAllBytes(encryptedFilePath, encryptedBytes);

        Console.WriteLine("Le fichier a été crypté avec succès.");
        Console.WriteLine($"Fichier crypté enregistré sous : {encryptedFilePath}");
    }
}
