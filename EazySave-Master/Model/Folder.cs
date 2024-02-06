namespace EazySave_Master.Model
{
    public class Folder
    {
        public string name { get; set; }
        public List<Folder> folders { get; set; }
        public List<File> files { get; set; }
    }
}