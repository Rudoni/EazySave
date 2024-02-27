
using System.IO;

namespace EazySave_Master
{
    public class EnumEasySaves
    {

        public const string FolderRoot = "EasySave";
        public const string FolderLogs = FolderRoot+"\\Logs";

        public enum ViewNames
        {
            Menu=1,
            Settings=2,
            CreateSaves=3,
            RunSaves=4
        }


    }
}
