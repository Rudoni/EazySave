﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class SaveTotal : Save
    {
        public SaveTotal(string name, string targetPath) : base(name, targetPath)
        {
        }

        public string name => throw new NotImplementedException();
    }
}
