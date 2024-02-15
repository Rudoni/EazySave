namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// representative class of the RealTime FileLog
    /// </summary>
    public class FileRTLogs : Logs
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
        string Logs.GetFileName()
        {
            return "state";
        }
    }
}
