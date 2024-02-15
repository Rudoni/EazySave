using System.Xml.Serialization;
using System;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// interface for logs
    /// </summary>
    public interface Logs
    {
        /// <summary>
        /// method to get the name of the file generated
        /// </summary>
        /// <returns>name of file</returns>
        public abstract string GetFileName();
    }
}