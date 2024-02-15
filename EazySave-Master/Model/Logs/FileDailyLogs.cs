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
    public class FileDailyLogs : Logs
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
        string Logs.GetFileName()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.ToString("yyyy-MM-dd");
        }
    }
}
