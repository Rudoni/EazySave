using System;
using System.IO;
using System.Xml.Serialization;

namespace EazySave_Master.Model


{
    public class DailyLog
    {
        public DateTime timeStamp { get; set; }
        public double transferTime { get; set; }
        public string name { get; set; }
        public string sourcePath { get; set; }
        public string destPath { get; set; }
        public long fileSize { get; set; }



    }
}