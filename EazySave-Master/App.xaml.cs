using System.Configuration;
using System.Data;
using System.Windows;
using System.Globalization;

namespace EazySave_Master
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //Point d'entrée de l'application

        public static void Main()
        {
            
            Console.WriteLine("Mode console !");



            //Code de récupération des infos linguistiques de l'OS

            CultureInfo culture = CultureInfo.CurrentCulture;

            // Affiche la langue par défaut de l'OS
            Console.WriteLine("Langue par défaut : " + culture.DisplayName);

            // Afficher le code de la langue (par exemple, "en-US" pour l'anglais aux États-Unis)
            Console.WriteLine("Code de la langue : " + culture.Name);

            // Afficher la direction de l'écriture (LTR pour Left To Right, RTL pour Right To Left)
            Console.WriteLine("Direction de l'écriture : " + (culture.TextInfo.IsRightToLeft ? "RTL" : "LTR"));




            Console.ReadLine();

        }

    }

}
