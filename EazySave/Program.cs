using EazySave.Languages;
using System.Resources;
using System.ComponentModel;
using System.Reflection;


class LangTest
{

    public static void Main(string[] args)
    {

        var lang = "fr";

        ResourceManager RM = new ResourceManager("EazySave.Languages."+lang, Assembly.GetExecutingAssembly());

        Console.WriteLine(RM.GetString("PremierNom"));


    }
}