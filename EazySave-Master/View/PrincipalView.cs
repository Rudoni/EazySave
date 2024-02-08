using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.View
{
    internal class PrincipalView
    {
        public string lang { get; set; }
        public PrincipalView() { }

        public void update(string lang)
        {
            ResourceManager resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());
            Console.WriteLine(resourceManager.GetString("Welcome") + "EazySave !");
            Console.WriteLine(resourceManager.GetString("CreateSave"));
            Console.WriteLine(resourceManager.GetString("GoSave"));
            Console.WriteLine(resourceManager.GetString("Settings"));

        }
    }
}