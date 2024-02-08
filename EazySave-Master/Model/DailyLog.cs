using System;

public class DailyLog
{
    public DateTime TimeStamp { get; set; }
    public string BackupName { get; set; }
    public string SourcePath { get; set; }
    public string DestPath { get; set; }
    public long FileSize { get; set; }
    public double TransferTime { get; set; }

    public DailyLog()
    {
       
    }
}
