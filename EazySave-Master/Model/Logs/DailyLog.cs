using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace EazySave_Master.Model.Logs
{ 
    /// <summary>
    /// representative class of a daily log
    /// </summary>
    public class DailyLog
    {
        /// <summary>
        /// name of the save
        /// </summary>
        [XmlElement("Name")]
        [JsonProperty("Name")]
        public string BackupName { get; set; }
        [XmlElement("FileSource")]
        [JsonProperty("FileSource")]
        public string SourcePath { get; set; }
        [XmlElement("FileTarget")]
        [JsonProperty("FileTarget")]
        public string DestPath { get; set; }
        [XmlElement("FileSize")]
        [JsonProperty("FileSize")]
        public long FileSize { get; set; }
        [XmlElement("FileTransferTime")]
        [JsonProperty("FileTransferTime")]
        public double TransferTime { get; set; }
        /// <summary>
        /// DateTime of the log save
        /// </summary>
        [XmlElement("time")]
        [JsonProperty("time")]
        public string TimeStamp { get; set; }

        //TODO
        public DailyLog(string name)
        {
            TimeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            BackupName = name;
            this.SourcePath = "slourcepath";
            this.DestPath = "destpath";
            this.FileSize = 1;
            this.TransferTime = 2;
        }

        public DailyLog()
        {
            TimeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            BackupName = "";
            this.SourcePath = "";
            this.DestPath = "";
            this.FileSize = 0;
            this.TransferTime = 0;
        }
    }
}
