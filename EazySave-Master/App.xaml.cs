using System.Configuration;
using System.Data;
using System.Windows;
using System.Globalization;
using System.Resources;
using System.Reflection;
using EazySave_Master.Model;

namespace EazySave_Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void Main()
        {
 
    ModelView.ModelView mv = new ModelView.ModelView();

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
                ResourceManager resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());

                Console.Clear();

                Console.WriteLine(resourceManager.GetString("Welcome") + "EazySave !");
                //Console.WriteLine(resourceManager.GetString("DefaultLanguage") + culture.DisplayName);
                //Console.WriteLine(resourceManager.GetString("CodeLanguage") + culture.Name);

                Console.WriteLine(resourceManager.GetString("Choices"));
                Console.WriteLine(resourceManager.GetString("CreateSave"));
                Console.WriteLine(resourceManager.GetString("GoSave"));
                Console.WriteLine(resourceManager.GetString("Settings"));
                Console.WriteLine(resourceManager.GetString("Leave"));



            var type = Console.ReadLine();
            switch (type)
            {
                case "1":
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

                    // Afficher le contenu de la liste avec une boucle foreach
                    foreach (Save s in mv.saves.saves)
                    {
                        Console.WriteLine(s.ToString());
                    }

                        //Appeler la fonction Sauv Tot ou dif avec les paramètres entrées par le user
                        //save.ExecuteSave(name, sourcePath, destPath, typeSave)

                        Console.WriteLine(resourceManager.GetString("MainMenu"));
                        Console.ReadLine();

                        break;
                case "2":
                        //Afficher liste des sauvegarde
                        foreach (Save s in mv.saves.saves)
                        {
                            Console.WriteLine(s.ToString());
                        }
                        Console.WriteLine(resourceManager.GetString("MainMenu"));
                        Console.ReadLine();
                        break;
                case "3": // Parameter (change language) 

                        Console.Clear();
                        Console.WriteLine(resourceManager.GetString("ChangeLanguage"));
                        Console.WriteLine(resourceManager.GetString("BackTwo"));
                        var typeParam = Console.ReadLine();

                        //Choix de l'utilisateur entre les paramètres
                        switch (typeParam)
                        {
                            case "1":

                                //Choix de la langue par l'utilisateur
                                Console.Clear();
                                Console.WriteLine(resourceManager.GetString("ChooseLanguage"));
                                Console.WriteLine("1. Français");
                                Console.WriteLine("2. English");
                                var typeLang = Console.ReadLine();

                                switch (typeLang)
                                {
                                    case "1":

                                        lang = "fr";
                                        break;

                                    case "2":

                                        lang = "en";
                                        break;

                                    default:
                                        break;


                                }
                                break;


                            case "2":
                                break;

                            default:
                                break;

                        }

                        break;
               
                case "4": // Leave
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

            }
        }

    }

}
