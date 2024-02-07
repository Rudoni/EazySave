using EazySave_Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace EazySave_Master.ModelView
{
    internal class ModelView
    {
        public ManageSaves saves;

        public ModelView() {
            saves = new ManageSaves();
        }

        public void createSave(string name, string targetPath, string sourceRepo,string typeSave)
        {
            switch (typeSave)
            {
                case "1":
                    saves.addSave(new SaveTotal(name,targetPath,sourceRepo));
                    break;
                case "2":
                    saves.addSave(new SaveDifferential(name, targetPath, sourceRepo));
                    break;
            }
        }
        public void runSave(string numbersUser)
        {
            saves.RunSaves(numbersUser);
       
        }
    }
}
