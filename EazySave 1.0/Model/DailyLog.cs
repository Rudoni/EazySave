using System;

namespace EazySave_Master.Model 
{ 
    /// <summary>
    /// representative class of a daily log
    /// </summary>
    public class DailyLog
    {
        /// <summary>
        /// DateTime of the log save
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// name of the save
        /// </summary>
        public string BackupName { get; set; }
        public string SourcePath { get; set; }
        public string DestPath { get; set; }
        public long FileSize { get; set; }
        public double TransferTime { get; set; }

        public DailyLog()
        {
       
        }
    }
}
