using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class SaveTotal : Save
    {
        public SaveTotal(string name, string targetPath, string sourceRepo) : base(name, targetPath, sourceRepo)
        {
        }
        public SaveTotal() { }  

        public string name => throw new NotImplementedException();

        protected override bool canFileBeCopied(string sourceFile, string destinationFile)
        {
            return true;
        }

        protected override string GetTypeName()
        {
            return "Total";
        }
    }
}
