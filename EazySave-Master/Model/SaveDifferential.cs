using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class SaveDifferential : Save
    {
        public SaveDifferential(int number, string name, string targetPath, string sourceRepo) : base(number, name, targetPath, sourceRepo)
        {
        }

        public string name => throw new NotImplementedException();

        /**
         * 
         */
        protected override bool canFileBeCopied(string sourceFile, string destinationFile)
        {
            bool dontExist = !File.Exists(destinationFile);
            bool modified = File.GetLastWriteTimeUtc(sourceFile) != File.GetLastWriteTimeUtc(destinationFile);
            return (dontExist || modified);
        }
        
    }
}
