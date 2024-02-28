using System;

namespace EazySave_Master.Model
{
    /// <summary>
    /// Type of save SaveTotal extend class Save
    /// </summary>
    class SaveTotal : Save
    {
        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        /// <param name="encryptList"></param>
        /// <param name="encryptKey"></param>
        public SaveTotal(string name, string sourceRepo, string targetPath, List<string> encryptList, string encryptKey) : base(name, sourceRepo, targetPath, encryptList, encryptKey)
        {

        }

        /// <summary>
        /// return always true
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="destinationFile"></param>
        /// <returns>true</returns>
        protected override bool canFileBeCopied(string sourceFile, string destinationFile)
        {
            return true;
        }

        /// <summary>
        /// Total 
        /// </summary>
        /// <returns>Total</returns>
        public override string GetTypeName()
        {
            return "Total";
        }
    }
}
