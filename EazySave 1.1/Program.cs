﻿using System.Globalization;
using System.Resources;
using System.Reflection;
using EazySave_Master.Model;
using EazySave_Master.View;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace EazySave_Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class EazySave
    {
        // Enum Main
        enum MainMenuOption
        {
            CreateSave = 1,
            RunSave = 2,
            ChangeParameters = 3
        }
        // Enum Parameter
        enum Parameters
        {
            ChangeLanguage = 1,
            ChangeLogExtension = 2,
            Return = 3
        }

        // Enum Languages
        enum LanguageOption
        {
            French = 1,
            English = 2
        }

        // Enum extension logs
        enum LogExtensions
        {
            JSON = 1,
            XML = 2
        }
        public static void Main()
        {

            ModelView.ModelView mv = new ModelView.ModelView();
            PrincipalView principalView = new PrincipalView();


            CultureInfo culture = CultureInfo.CurrentCulture;
            string lang = "en"; // Default Language

            switch (culture.Name.ToLower())
            {
                case "fr-fr":
                    lang = "fr";
                    break;
                default:
                    break;
            }

            while (true)
            {
                Console.Clear();
                ResourceManager resourceManager = new ResourceManager("EazySave_1._1.Languages." + lang, Assembly.GetExecutingAssembly());
                principalView.update(lang);

                Console.WriteLine(resourceManager.GetString("MainMenu"));
                var userInput = Console.ReadLine();

                if (Enum.TryParse(userInput, out MainMenuOption mainMenuOption))
                {
                    switch (mainMenuOption)
                    {
                        // Create Save
                        case MainMenuOption.CreateSave:
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
                            break;

                        // Run Save
                        case MainMenuOption.RunSave:
                            foreach (Save s in mv.saves.saves)
                            {
                                Console.WriteLine(s.ToString());
                            }
                            Console.WriteLine(resourceManager.GetString("Test"));
                            String numberUser = Console.ReadLine();
                            mv.runSavesFromNumbers(numberUser);
                            Console.WriteLine(resourceManager.GetString("MainMenu"));
                            Console.ReadLine();
                            break;

                        // Parameters
                        case MainMenuOption.ChangeParameters:
                            Console.Clear();
                            Console.WriteLine(resourceManager.GetString("ChangeLanguage"));
                            Console.WriteLine(resourceManager.GetString("ChangeLogExtension"));
                            Console.WriteLine(resourceManager.GetString("BackTwo"));

                            var userInput2 = Console.ReadLine();
                            if (Enum.TryParse(userInput2, out Parameters parameters))
                            {
                                switch (parameters)
                                {
                                    case Parameters.ChangeLanguage:
                                        Console.Clear();
                                        Console.WriteLine("1. Choisir Français");
                                        Console.WriteLine("2. Choose English");
                                        var langChoice = Console.ReadLine();

                                        // Change language
                                        if (Enum.TryParse(langChoice, out LanguageOption language))
                                        {
                                            switch (language)
                                            {
                                                case LanguageOption.French:
                                                    lang = "fr";
                                                    break;
                                                case LanguageOption.English:
                                                    lang = "en";
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        break;

                                    case Parameters.ChangeLogExtension:
                                        Console.Clear();
                                        Console.WriteLine("1. JSON");
                                        Console.WriteLine("2. XML");
                                        var extChoice = Console.ReadLine();
                                        // Change extension
                                        if (Enum.TryParse(extChoice, out LogExtensions ext))
                                        {
                                            switch (ext)
                                            {
                                                case LogExtensions.JSON:
                                                    mv.UpdateExtensionLog(1);
                                                    break;
                                                case LogExtensions.XML:
                                                    mv.UpdateExtensionLog(2);
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        break;


                                    case Parameters.Return:

                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }

    }

}