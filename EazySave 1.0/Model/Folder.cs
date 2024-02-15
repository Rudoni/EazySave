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
    }
}