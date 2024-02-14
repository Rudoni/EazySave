using System;
using System.Numerics;

public class RealTimeLog
{
    //Date of the backup
    public DateTime TimeStamp { get; set; }

    //Name of the current backup
    public string BackupName { get; set; }

    //State of the save (Active or Inactive)
    public string SaveState { get; set; }

    //Total number of files in the backup
    public int TotalFile { get; set; }

    //Total size of the files in the backup (in kilobytes)
    public long TotalSize { get; set; }

    //Current progress of the save (percentage)
    public double progress { get; set; }

    //Number of remaining files to back up
    public int FilesLeft { get; set; }

    //Total size of remaining files to back up (in kilobytes)
    public long SizeLeft { get; set; }

    //Source path of the current file
    public string sourcePath { get; set; }

    //Destination path of the current file
    public string destinationPath { get; set; }

    public RealTimeLog()
    {

    }

    static double calculateProgress(long totalSize, long sizeLeft)
    {
        return Math.Max(0.0, Math.Min(1.0, (double)(totalSize - sizeLeft) / Math.Max(1, totalSize)));
    }

}