using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// Class representing logs in JSON format
    /// </summary>
    public class JSONLogs : TypeFileLogs
    {
        /// <summary>
        /// get the extension of the JSON file
        /// </summary>
        /// <returns></returns>
        public override string GetExtensionFile()
        {
            return "json";
        }

        /// <summary>
        /// Specific method to generate a log file from a log class
        /// </summary>
        /// <param name="logs">Instance of the log class</param>
        public override void RunLogs(Logs logs)
        {
            string logFilePath = this.GetLogFilePath(logs);

            // Check if the file exists
            if (System.IO.File.Exists(logFilePath))
            {
                // Read existing content from the file
                string existingContent = System.IO.File.ReadAllText(logFilePath);
                JArray existingArray = JArray.Parse(existingContent);
                string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);
                JObject newLog = JObject.Parse(jsonLogs);
                existingArray.Add(newLog);
                System.IO.File.WriteAllText(logFilePath, existingArray.ToString());
            }
            else
            {
                // If the file doesn't exist, create a new JSON file with the new log data
                JArray newArray = new JArray();
                string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);
                newArray.Add(JObject.Parse(jsonLogs));
                System.IO.File.WriteAllText(logFilePath, newArray.ToString());
            }
        }
    }
}
