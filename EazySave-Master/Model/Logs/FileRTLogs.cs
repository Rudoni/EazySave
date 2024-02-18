namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// representative class of the RealTime FileLog
    /// </summary>
    public class FileRTLogs : FileLogs
    {
        /// <summary>
        /// list of RealTimeLog
        /// </summary>
        public List<RealTimeLog> lRealTimeLogs { get; set; }

        public FileRTLogs()
        {
            lRealTimeLogs = new List<RealTimeLog>();
        }

        /// <summary>
        /// method to get the name of the file generated
        /// </summary>
        /// <returns>state</returns>
        public string GetFileName()
        {
            return "state";
        }

        public void AddLog(Log log)
        {
            this.lRealTimeLogs.Add((RealTimeLog)log);
        }

        public bool IsEmpty()
        {
            return !this.lRealTimeLogs.Any();
        }

        public void EmptyLogs()
        {
            this.lRealTimeLogs.Clear();
        }
    }
}
