using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;

namespace EazySave_Master.Model.Logs {
    public class RealTimeLog
    {
        //Name of the current backup
        public string BackupName { get; set; }

        //State of the save (Active or Inactive)
        public string saveState { get; set; }

        //Total number of files in the backup
        public int totalFile { get; set; }

        //Total size of the files in the backup
        public long totalSize { get; set; }

        //Current progress of the save (percentage)
        public double progress { get; set; }

        //Number of remaining files to back up
        public int filesLeft { get; set; }

        //Total size of remaining files to back up
        public long sizeLeft { get; set; }


        public RealTimeLog(string name, int totalFile, long totalSize)
        {
            this.BackupName = name;
            setSaveState(false);
            this.totalFile = totalFile;
            this.totalSize = totalSize;
            this.progress = 0;
            this.filesLeft = totalFile;
            this.sizeLeft = totalSize;
        }

        public RealTimeLog()
        {
            this.BackupName = "";
            setSaveState(false);
            this.totalFile = 0;
            this.totalSize = 0;
            this.progress = 0;
            this.filesLeft = 0;
            this.sizeLeft = 0;
        }

        public void refreshState(int filesFinished, long sizeFinished)
        {
            this.filesLeft = totalFile - filesFinished;
            this.sizeLeft = totalSize - sizeFinished;
        }

        public void setSaveState(bool active)
        {
            if (active)
                saveState = "ACTIVE";
            else
                saveState = "END";
        }


    }
}