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
            save = new SaveTotal(1, "name", "C:\\Users\\test", "C:\\Users");
        }

        public void SaveTotalll()
        {
            save.ExecuteSave();
       
        }
    }
}
