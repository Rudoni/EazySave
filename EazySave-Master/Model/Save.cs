using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class Save
    {
        public int number { get; set; }
        public string name { get; set; }
        public string targetPath { get; set; }
        public SaveType saveType { get; set; }
        public Folder sourceRepo { get; set; }

        public Save(string name, string targetPath)
        {
            this.name = name;
            this.targetPath = targetPath;
        }

        //TODO a completer
        internal void ExecuteSave()
        {
            
        }
    }
}
