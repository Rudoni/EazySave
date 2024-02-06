using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EazySave_Master.Model
{
    class DailyLogs
    {
        private static readonly string logFilePath = "../Log/log.xml";

        public static void Log(string name, string sourcePath, string destinationPath, long fileSize, int transferTime)
        {
            try
            {
                DailyLog logEntry = new DailyLog()
                {
                    timeStamp = DateTime.Now,
                    name = name,
                    sourcePath = sourcePath,
                    destPath = destinationPath,
                    fileSize = fileSize,
                    transferTime = transferTime
                };

                XmlSerializer serializer = new XmlSerializer(typeof(DailyLog));

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    serializer.Serialize(writer, logEntry);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'écriture dans le fichier de log : {ex.Message}");
            }
        }
    }
}
