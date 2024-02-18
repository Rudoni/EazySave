using Newtonsoft.Json;
using System.Xml.Serialization;

namespace EazySave_Master.Model.Logs
{ 
    /// <summary>
    /// representative class of a daily log
    /// </summary>
    public class DailyLog:Log
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        /// <param name="fileSize"></param>
        /// <param name="transferTime"></param>
        public DailyLog(string name,string sourcePath,string targetPath,long fileSize,double transferTime)
        {
            TimeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            BackupName = name;
            this.SourcePath = sourcePath;
            this.DestPath = targetPath;
            this.FileSize = fileSize;
            this.TransferTime = transferTime;
        }

        public DailyLog(Save save)
        {
            this.TimeStamp = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            this.BackupName = save.name;
            this.SourcePath = save.sourceRepo.path;
            this.DestPath = save.targetPath;
            this.FileSize = Folder.GetTotalFileSize(save.sourceRepo.path);
            this.TransferTime = 0; 
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
