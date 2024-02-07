using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EazySave_Master.Model
{
    abstract class Save
    {
        public int number { get; set; }
        public string name { get; set; }
        public string targetPath { get; set; }
        public Folder sourceRepo { get; set; }

        public Save(string name, string targetPath, string sourceRepo)
        {
            this.number = 0;
            this.name = name;
            this.targetPath = targetPath;
            this.sourceRepo = new Folder(sourceRepo);
        }

        public Save()
        {
            
        }

        public void setNumber(int n)
        {
            this.number = n;
        }

        //TODO a completer
        public void ExecuteSave()
        {
            string sourcePath = sourceRepo.path;
           

            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine("Le chemin source n'existe pas.");
                return;
            }

            if (!Directory.Exists(targetPath))
            {
                Console.WriteLine("Le chemin de destination n'existe pas.");
                return;
            }

            CopyDirectory(sourcePath, targetPath);
        }

        private void CopyDirectory(string sourcePath, string targetPath)
        {
            Directory.CreateDirectory(targetPath);

            string[] filesSource = Directory.GetFiles(sourcePath);

            foreach (string filePath in filesSource)
            {
                string fileName = Path.GetFileName(filePath);
                string targetFilePath = Path.Combine(targetPath, fileName);

               
                if (canFileBeCopied(filePath, targetFilePath))
                {
                    Directory.CreateDirectory(targetPath);
                    System.IO.File.Copy(filePath, targetFilePath, true);
                    Console.WriteLine($"Copie de fichier : {fileName}");
                }
            }

            string[] subDirectories = Directory.GetDirectories(sourcePath);

            foreach (string subDirectoryPath in subDirectories)
            {
                string subDirectoryName = Path.GetFileName(subDirectoryPath);
                string targetSubDirectoryPath = Path.Combine(targetPath, subDirectoryName);
                CopyDirectory(subDirectoryPath, targetSubDirectoryPath);
            }
        }

        protected abstract bool canFileBeCopied(string sourceFile, string destinationFile);
    }
}
