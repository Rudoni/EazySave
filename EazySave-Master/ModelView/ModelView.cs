﻿using EazySave_Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.ModelView
{
    internal class ModelView
    {

        public Save save;


        public ModelView() { 
            save = new SaveDifferential(1, "name", @"C:\test5", @"C:\test");
        }

        public void SaveTotalll()
        {
            save.ExecuteSave();
       
        }
    }
}
