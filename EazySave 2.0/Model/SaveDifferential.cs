using System;
using System.IO;

namespace EazySave_Master.Model
{
    /// <summary>
    /// Type of save SaveDifferential extend class Save
    /// </summary>
    class SaveDifferential : Save
    {

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        /// <param name="encryptList"></param>
        /// <param name="encryptKey"></param>
        public SaveDifferential(string name, string sourceRepo, string targetPath, List<string> encryptList, string encryptKey) : base(name, sourceRepo, targetPath, encryptList, encryptKey)
        {
        }

        /// <summary>
        /// override of Save method
        /// return true if file dont exist already
        ///  or file not modified from the difference between LastWriteTime source and destination
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        /// <returns></returns>
        protected override bool canFileBeCopied(string sourceFile, string destinationFile)
        {
            bool dontExist = !File.Exists(destinationFile);
            bool modified = File.GetLastWriteTimeUtc(sourceFile) != File.GetLastWriteTimeUtc(destinationFile);
            return (dontExist || modified);
        }

        /// <summary>
        /// Differential 
        /// </summary>
        /// <returns>Differential</returns>
        public override string GetTypeName()
        {
            return "Differential";
        }
    }
}
