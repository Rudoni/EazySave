using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    public class UserFile
    {
        public string name { get; set; }
        public double size { get; set; }
        public DateTime lastModified { get; set; }
    }
}
