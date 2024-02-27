
using System.IO;

namespace EazySave_Master
{
    public class EnumEasySaves
    {

        public const string FolderRoot = "EasySave";
        

        public enum ViewNames
        {
            Menu=1,
            Settings=2,
            CreateSaves=3,
            RunSaves=4
        }
        public enum LogFormat
        {
            Json=1,
            Xml=2
        }

    }
}
