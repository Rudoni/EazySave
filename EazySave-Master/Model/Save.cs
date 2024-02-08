using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace EazySave_Master.Model
{
    abstract class Save
    {
        public int number { get; set; }
        public string name { get; set; }
        public string targetPath { get; set; }
        public Folder sourceRepo { get; set; }
        public List<DailyLog> logs { get; set; } 


        public Save(string name, string sourceRepo, string targetPath)
        {
            this.number = 0;
            this.name = name;
            this.sourceRepo = new Folder(sourceRepo);
            this.targetPath = targetPath;
            this.logs = new List<DailyLog>(); 

        }

        public Save()
        {
            this.logs = new List<DailyLog>(); 
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
                Console.WriteLine($"Save n°{number}: Source path don't exist.");
                return;
            }

            if (!Directory.Exists(targetPath))
            {
                Console.WriteLine($"Save n°{number}: Target path don't exist.");
                return;
            }

            CopyDirectory(sourcePath, targetPath);
            Console.WriteLine($"Save n°{number}: Done.");

            // Add Log for each Save
            AddLog();
            SaveLogsToJson();
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




        public override string ToString()
        {
            return $" - Number: {number}\n - Name: {name}\n - Source: {sourceRepo.path}\n - Destination: {targetPath}\n - Type: {this.GetTypeName()}";
        }
        protected abstract bool canFileBeCopied(string sourceFile, string destinationFile);

        protected abstract string GetTypeName();


        // Part Log

        private double CalculateTransferTime(string sourcePath, string targetPath)
        {
            DateTime startTime = DateTime.Now;
            CopyDirectory(sourcePath, targetPath);
            DateTime endTime = DateTime.Now;
            TimeSpan transferDuration = endTime - startTime;
            double transferTimeMilliseconds = transferDuration.TotalMilliseconds;

            return transferTimeMilliseconds;
        }

        private long GetTotalFileSize(string sourcePath)
        {
            string[] files = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
            long totalFileSize = 0;

            foreach (string filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                totalFileSize += fileInfo.Length;
            }

            return totalFileSize;
        }


        private void AddLog()
        {
            DailyLog log = new DailyLog();

            log.TimeStamp = DateTime.Now;
            log.BackupName = this.name; 
            log.SourcePath = sourceRepo.path;
            log.DestPath = targetPath;
            log.FileSize = GetTotalFileSize(sourceRepo.path); 
            log.TransferTime = CalculateTransferTime(sourceRepo.path, targetPath); 

            logs.Add(log);
        }
        
        private void SaveLogsToJson()
        {
            string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);
            string logFilePath = "../../../Log/log.json"; //   ./Log/log.json      -> When build for .exe

            System.IO.File.WriteAllText(logFilePath, jsonLogs);
        }

    }
}
