using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    abstract class Save
    {
        public int number { get; set; }
        public string name { get; set; }
        public string targetPath { get; set; }
        public Folder sourceRepo { get; set; }

        public Save(int number, string name, string targetPath, string sourceRepo)
        {
            this.number = number;
            this.name = name;
            this.targetPath = targetPath;
            this.sourceRepo = new Folder(sourceRepo);
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

            string[] filesSource = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);

            foreach (string file in filesSource)
            {
                if (CompareForDifferential(file, targetPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                    File.Copy(file, targetPath, true);
                    Console.WriteLine($"Copie de fichier");
                }
            }
        }

        protected abstract bool CompareForDifferential(string sourceFile, string destinationFile);
    }
}
