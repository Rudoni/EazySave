using System;
using System.Reflection;
using System.Resources;

namespace EazySave_Master.View
{
    internal class PrincipalView
    {
        public string lang { get; set; }
        public PrincipalView() { }

        public void update(string lang)
        {
            ResourceManager resourceManager = new ResourceManager("EazySave_1._1.Languages." + lang, Assembly.GetExecutingAssembly());
            Console.WriteLine(resourceManager.GetString("Welcome") + "EazySave !");
            Console.WriteLine(resourceManager.GetString("CreateSave"));
            Console.WriteLine(resourceManager.GetString("GoSave"));
            Console.WriteLine(resourceManager.GetString("Settings"));

        }
    }
}