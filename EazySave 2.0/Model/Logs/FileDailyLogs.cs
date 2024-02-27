using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// representative class of the Daily FileLog
    /// </summary>
    public class FileDailyLogs : FileLogs
    {
        /// <summary>
        /// list of DailyLog
        /// </summary>
        public List<DailyLog> lDailyLogs { get; set; }

        public FileDailyLogs()
        {
            lDailyLogs = new List<DailyLog>();
        }

        /// <summary>
        /// method to get the name of the file generated
        /// </summary>
        /// <returns>current date in format "yyyy-MM-dd"</returns>
        public string GetFileName()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.ToString("yyyy-MM-dd");
        }

        public void AddLog(Log log)
        {
            this.lDailyLogs.Add((DailyLog)log);
        }

        public bool IsEmpty()
        {
            return !this.lDailyLogs.Any();
        }

        public void EmptyLogs()
        {
            this.lDailyLogs.Clear();
        }
    }
}
