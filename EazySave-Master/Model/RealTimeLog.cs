using Newtonsoft.Json;
using System;
using System.IO;

public class RealTimeLog
{
    //Date of the backup
    public DateTime TimeStamp { get; set; }

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
    public int sizeLeft { get; set; }

    //Source path of the current file
    public string sourcePath { get; set; }

    //Destination path of the current file
    public string destPath { get; set; }



    public RealTimeLog()
    {

    }

    


}