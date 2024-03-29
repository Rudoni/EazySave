﻿using EazySave_Master.Model.Logs;
using Newtonsoft.Json;
using System.IO;
using static System.Net.WebRequestMethods;

namespace EazySave_Master.Model
{
    /// <summary>
    /// Representative Class of a save
    /// </summary>
    public abstract class Save
    {
        /// <summary>
        /// number of the save (auto-incremented in ManageSaves)
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// name of the save
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Path of the target repository
        /// </summary>
        public string targetPath { get; set; }
        /// <summary>
        /// Source repository, path contained in Folder.path
        /// </summary>
        public Folder sourceRepo { get; set; }


        /// <summary>
        /// Default constructor, completed by user inputs
        /// number is assigned automatically in addSave of ManageSaves
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        public Save(string name, string sourceRepo, string targetPath)
        {
            this.number = 0;
            this.name = name;
            this.sourceRepo = new Folder(sourceRepo);
            this.targetPath = targetPath;

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Save()
        {
            this.number = 0;
            this.name = "";
            this.sourceRepo = new Folder("");
            this.targetPath = "";
        }

        /// <summary>
        /// setter for Number
        /// </summary>
        /// <param name="n">Number</param>
        public void setNumber(int n)
        {
            this.number = n;
        }

        /// <summary>
        /// Launch the actual save after some verifications
        /// </summary>
        public bool ExecuteSave()
        {

            string sourcePath = sourceRepo.path;


            if (!Directory.Exists(sourcePath))
            {
                Console.WriteLine($"Save n°{number}: Source path don't exist.");
                return false;
            }

            if (!Directory.Exists(targetPath))
            {
                Console.WriteLine($"Save n°{number}: Target path don't exist.");
                return false;
            }

            CopyDirectory(sourcePath, targetPath);
            Console.WriteLine($"Save n°{number}: Done.");

            // Add Log for each Save

            return true;
        }

        /// <summary>
        /// Copy the directory and all the subdirectory from sourcePath to targetPath recursively
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
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

        /// <summary>
        /// abstract method used in CopyDirectory, it add a verification so if true is returned, the copy is launched
        /// (to implement in sub class)
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        /// <returns>bool true if copy will be launched</returns>
        protected abstract bool canFileBeCopied(string sourceFile, string destinationFile);

        /// <summary>
        /// abstract method to get the name of the SaveType
        /// </summary>
        /// <returns>string name TypeSave</returns>
        protected abstract string GetTypeName();


//*********** Part Log

        /// <summary>
        /// calcul of the transferTime of a directory
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <returns>time in double</returns>
        private double CalculateTransferTime(string sourcePath, string targetPath)
        {
            DateTime startTime = DateTime.Now;
            CopyDirectory(sourcePath, targetPath);
            DateTime endTime = DateTime.Now;
            TimeSpan transferDuration = endTime - startTime;
            double transferTimeMilliseconds = transferDuration.TotalMilliseconds;

            return transferTimeMilliseconds;
        }
       

    }
}
