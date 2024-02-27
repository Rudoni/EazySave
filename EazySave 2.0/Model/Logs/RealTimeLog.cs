using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;

namespace EazySave_Master.Model.Logs {
    public class RealTimeLog:Log
    {
        /// <summary>
        /// name of save
        /// </summary>
        public string BackupName { get; set; }

        /// <summary>
        /// State of the save (Active or Inactive)
        /// </summary>
        public string saveState { get; set; }

        /// <summary>
        /// Total number of files
        /// </summary>
        public int totalFile { get; set; }

        /// <summary>
        /// Total size of the files
        /// </summary>
        public long totalSize { get; set; }

        /// <summary>
        /// Current progress of the save (percentage)
        /// </summary>
        public double progress { get; set; }

        /// <summary>
        /// Number of remaining files to back up
        /// </summary>
        public int filesLeft { get; set; }

        /// <summary>
        /// Total size of remaining files to back up
        /// </summary>
        public long sizeLeft { get; set; }


        public RealTimeLog(string name, int totalFile, long totalSize)
        {
            this.BackupName = name;
            this.setSaveState(false);
            this.totalFile = totalFile;
            this.totalSize = totalSize;
            this.progress = 0;
            this.filesLeft = totalFile;
            this.sizeLeft = totalSize;
        }

        public RealTimeLog()
        {
            this.BackupName = "";
            this.setSaveState(false);
            this.totalFile = 0;
            this.totalSize = 0;
            this.progress = 0;
            this.filesLeft = 0;
            this.sizeLeft = 0;
        }

        public void MaJFromSave(Save save)
        {
            this.BackupName = save.name;
            this.setSaveState(true);
            this.totalFile = Folder.GetTotalFileNumber(save.sourceRepo.path);
            this.totalSize = Folder.GetTotalFileSize(save.sourceRepo.path);
            this.progress = 0;
            this.filesLeft = Folder.GetTotalFileNumber(save.sourceRepo.path);
            this.sizeLeft = Folder.GetTotalFileSize(save.sourceRepo.path);
        }

        public void refreshState(int filesFinished, long sizeFinished)
        {
            this.filesLeft = totalFile - filesFinished;
            this.sizeLeft = totalSize - sizeFinished;
        }

        public void setSaveState(bool active)
        {
            if (active)
                this.saveState = "ACTIVE";
            else
                this.saveState = "END";
        }

        public void saveFinished()
        {
            this.filesLeft = 0;
            this.sizeLeft = 0;
            this.setSaveState(false);
        }
    }
}