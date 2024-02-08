using System.Configuration;
using System.Data;
using System.Windows;
using System.Globalization;
using System.Resources;
using System.Reflection;
using EazySave_Master.Model;
using EazySave_Master.View;

namespace EazySave_Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Enum Main
        enum MainMenuOption
        {
            CreateSave = 1,
            RunSave = 2,
            ChangeLanguage = 3
        }
        // Enum Parameter
        enum Parameters
        {
            ChangeLanguage = 1,
            Return = 2
        }

        // Enum Languages
        enum LanguageOption
        {
            French = 1,
            English = 2
        }
        public static void Main()
        {

            ModelView.ModelView mv = new ModelView.ModelView();
            PrincipalView principalView = new PrincipalView();
            CreateView createView = new CreateView();
            RunSave runSave = new RunSave();

            CultureInfo culture = CultureInfo.CurrentCulture;
            string lang = "en"; // Langue par défaut

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
                ResourceManager resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());
                principalView.update(lang);

                Console.WriteLine(resourceManager.GetString("MainMenu"));
                var userInput = Console.ReadLine();

                // Convertir l'entrée utilisateur en enum MainMenuOption
                if (Enum.TryParse(userInput, out MainMenuOption mainMenuOption))
                {
                    switch (mainMenuOption)
                    {
                        // Create Save
                        case MainMenuOption.CreateSave:
                            createView.update(lang);
                            break;

                        // Run Save
                        case MainMenuOption.RunSave:
                            runSave.update(lang);
                            break;

                        // Parameters
                        case MainMenuOption.ChangeLanguage:
                            Console.Clear();
                            Console.WriteLine(resourceManager.GetString("ChangeLanguage"));
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
