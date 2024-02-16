using System.Xml.Serialization;
using System;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// interface for logs
    /// </summary>
    public interface FileLogs
    {
        /// <summary>
        /// method to get the name of the file generated
        /// </summary>
        /// <returns>name of file</returns>
        public abstract string GetFileName();

        /// <summary>
        /// add a log to the list
        /// </summary>
        public abstract void AddLog(Log log);

        /// <summary>
        /// empty the list
        /// </summary>
        public abstract void EmptyLogs();

        /// <summary>
        /// return true if list is empty
        /// </summary>
        /// <returns>bool</returns>
        public abstract bool IsEmpty();
    }
}