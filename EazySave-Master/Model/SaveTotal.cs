using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class SaveTotal : Save
    {
        public SaveTotal(int number, string name, string targetPath, string sourceRepo) : base(number, name, targetPath, sourceRepo)
        {
        }

        public string name => throw new NotImplementedException();

        protected override bool CompareForDifferential(string sourceFile, string destinationFile)
        {
            return true;
        }
    }
}
