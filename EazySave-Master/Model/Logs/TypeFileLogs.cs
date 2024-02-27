using System.IO;
using System.Xml.Serialization;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// representative abstract class for types of files used for logs
    /// </summary>
    public abstract class TypeFileLogs
    {
        /// <summary>
        /// return the full path name where the log file will be generated
        /// create the repository "EazySaveLogs" if not already existing
        /// </summary>
        /// <param name="logs">FileLog</param>
        /// <returns>full path</returns>
        public string GetLogFilePath(FileLogs logs)
        {
            //path to the folder of logs from appdata
            string foldersLogs = EnumEasySaves.FolderLogs;
            //check existing directory in appdata
            string pathFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), foldersLogs);
            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
            }
            //name of file with extension
            string completeNameFile = logs.GetFileName() + "." + this.GetExtensionFile();
            // concat Name + date 
            return Path.Combine(pathFolder, completeNameFile);

        }

        /// <summary>
        /// run the generating method of logs
        /// </summary>
        /// <param name="logs">FileLog</param>
        public abstract void RunLogs(FileLogs logs);
        
        /// <summary>
        /// return the extension of the type of log
        /// </summary>
        /// <returns>extension de fichier</returns>
        public abstract string GetExtensionFile();

    }
}