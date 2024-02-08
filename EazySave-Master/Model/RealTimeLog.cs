using Newtonsoft.Json;
using System;
using System.IO;

public class RealTimeLog
{
    //Name of the current backup
    public string BackupName { get; set; }

    //State of the save (Active or Inactive)
    public string saveState { get; set; }

    //Total number of files in the backup
    public int totalFile { get; set; }

    //Total size of the files in the backup
    public Int128 totalSize { get; set; }

    //Current progress of the save (percentage)
    public double progress { get; set; }

    //Number of remaining files to back up
    public int filesLeft { get; set; }

    //Total size of remaining files to back up
    public Int128 sizeLeft { get; set; }


    public RealTimeLog(string name, int totalFile, Int128 totalSize)
    {
        this.BackupName = name;
        setSaveState(false);
        this.totalFile = totalFile;
        this.totalSize = totalSize;
        this.progress = 0;
        this.filesLeft = totalFile;
        this.sizeLeft = totalSize;
    }

    public void refreshState(int filesLeft,  Int128 sizeLeft)
    {
        this.filesLeft = filesLeft;
        this.sizeLeft = sizeLeft;
    }

    public void setSaveState(bool active)
    {
        if (active)
            saveState = "ACTIVE";
        else
            saveState = "END";
    }
    


}