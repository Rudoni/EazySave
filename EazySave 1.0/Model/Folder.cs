using System.IO;

namespace EazySave_Master.Model
{
    /// <summary>
    /// representative class of a folder
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// complete path of the folder
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// list of folder in the folder
        /// </summary>
        public List<Folder> folders { get; set; }
        /// <summary>
        /// list of files in the folder
        /// </summary>
        public List<UserFile> files { get; set; }

        /// <summary>
        /// default constructor of a folder by his path
        /// </summary>
        /// <param name="path"></param>
        public Folder(string path) {
            this.path = path;
            folders = new List<Folder>();
            files = new List<UserFile>();
        }

        /// <summary>
        /// calcul the total file size from a directory
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <returns>total file size in long</returns>
        public static long GetTotalFileSize(string sourcePath)
        {
            string[] files = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
            long totalFileSize = 0;

            foreach (string filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                totalFileSize += fileInfo.Length;
            }

            return totalFileSize;
        }

        /// <summary>
        /// calcul the total number of file in a directory
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <returns></returns>
        public static int GetTotalFileNumber(string sourcePath)
        {
            int res = 0;
            DirectoryInfo dirInfo= new DirectoryInfo(sourcePath);
            res += dirInfo.GetFiles().Length;

            foreach (DirectoryInfo subDir in dirInfo.GetDirectories())
            {
                res += GetTotalFileNumber(subDir.FullName);
            }

            return res;
        }
    }
}