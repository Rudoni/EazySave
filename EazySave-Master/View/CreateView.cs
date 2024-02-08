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
    internal class CreateView
    {
        public string lang { get; set; }

        ModelView.ModelView mv = new ModelView.ModelView();
        public CreateView() { }

        public void update(string lang)
        {
            ResourceManager resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());
            Console.Clear();
            Console.WriteLine(resourceManager.GetString("EnterName"));
            String name = Console.ReadLine();
            Console.WriteLine(resourceManager.GetString("SourcePath"));
            String sourcePath = Console.ReadLine();
            Console.WriteLine(resourceManager.GetString("DestPath"));
            String destPath = Console.ReadLine();
            Console.WriteLine(resourceManager.GetString("SaveType"));
            Console.WriteLine(resourceManager.GetString("Complete"));
            Console.WriteLine(resourceManager.GetString("Differential"));
            String typeSave = Console.ReadLine();

            mv.createSave(name, sourcePath, destPath, typeSave);

            // List Save
            foreach (Save s in mv.saves.saves)
            {
                Console.WriteLine(s.ToString());
            }

            Console.WriteLine(resourceManager.GetString("MainMenu"));
            Console.ReadLine();

        }
    }
}
