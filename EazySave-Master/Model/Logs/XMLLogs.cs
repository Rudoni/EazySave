using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EazySave_Master.Model.Logs
{
    /// <summary>
    /// Class representing logs in XML format
    /// </summary>
    public class XMLLogs : TypeFileLogs
    {
        /// <summary>
        /// get the extension of the XML file
        /// </summary>
        /// <returns></returns>
        public override string GetExtensionFile()
        {
            return "xml";
        }

        /// <summary>
        /// Specific method to generate a log file in XML format from a log class
        /// </summary>
        /// <param name="logs">Instance of the log class</param>
        public override void RunLogs(Logs logs)
        {
            string logFilePath = this.GetLogFilePath(logs);

            XmlDocument xmlDoc = new XmlDocument();

            //serialize
            using (MemoryStream memoryStream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(logs.GetType());
                serializer.Serialize(memoryStream, logs);
                memoryStream.Seek(0, SeekOrigin.Begin);
                xmlDoc.Load(memoryStream);
            }

            bool fileExists = File.Exists(logFilePath);

            XmlDocument existingXmlDoc = new XmlDocument();
            //if file doesnt exist, just create a new file complete
            if (!fileExists)
            {
                xmlDoc.Save(logFilePath);
            }
            else
            {
                // Load the existing XML content into an XmlDocument object
                existingXmlDoc.Load(logFilePath);
                XmlNodeList nodes = existingXmlDoc.DocumentElement.ChildNodes;
                //at the 2nd node
                if (nodes.Count >= 2)
                {
                    XmlNode secondNode = nodes[1];
                    XmlNode importedNode = existingXmlDoc.ImportNode(xmlDoc.DocumentElement, true);
                    secondNode.AppendChild(importedNode);
                }
                else
                {
                    XmlNode importedNode = existingXmlDoc.ImportNode(xmlDoc.DocumentElement, true);
                    existingXmlDoc.DocumentElement.AppendChild(importedNode);
                }

                existingXmlDoc.Save(logFilePath);
            }
        }
    }
}