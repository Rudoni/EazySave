using EazySave_Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.View
{
    internal class RunSave
    {
        public string lang { get; set; }

        ModelView.ModelView mv = new ModelView.ModelView();
        public RunSave() { }

        public void update(string lang)
        {
            ResourceManager resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());
            //List Save
            foreach (Save s in mv.saves.saves)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine(resourceManager.GetString("Test"));
            String numberUser = Console.ReadLine();
            mv.runSave(numberUser);
            Console.WriteLine(resourceManager.GetString("MainMenu"));
            Console.ReadLine();

        }
    }
}
