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
        public string GetLogFilePath(Logs logs)
        {
            //check existing directory in appdata
            string checkEnv = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EazySaveLogs");
            if (!Directory.Exists(checkEnv))
            {
                Directory.CreateDirectory(checkEnv);
            }
            //name of file with extension
            string completeNameFile = logs.GetFileName() + "." + this.GetExtensionFile();
            // concat Name + date 
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EazySaveLogs", completeNameFile);

        }

        /// <summary>
        /// run the generating method of logs
        /// </summary>
        /// <param name="logs">FileLog</param>
        public abstract void RunLogs(Logs logs);
        
        /// <summary>
        /// return the extension of the type of log
        /// </summary>
        /// <returns>e</returns>
        public abstract string GetExtensionFile();

    }
}