namespace EazySave_Master.Model
{
    public class Folder
    {
        public string path { get; set; }
        public List<Folder> folders { get; set; }
        public List<UserFile> files { get; set; }

        public Folder(string path) {
            this.path = path;
            folders = new List<Folder>();
            files = new List<UserFile>();
        }
    }
}