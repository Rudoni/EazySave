using System;

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

    //Total size of the files in the backup
    public Int128 TotalSize { get; set; }

    //Current progress of the save (percentage)
    public double progress { get; set; }

    //Number of remaining files to back up
    public int FilesLeft { get; set; }

    //Total size of remaining files to back up
    public int SizeLeft { get; set; }

    //Source path of the current file
    public string sourcePath { get; set; }

    //Destination path of the current file
    public string destinationPath { get; set; }



    public RealTimeLog()
    {

    }
}