using EazySave_Master.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace EazySave_Master.ModelView
{
    /// <summary>
    /// ViewModel between the view and model ManageSaves
    /// </summary>
    public class ModelView
    {
        public ManageSaves saves {set; get; }

  
        private static ModelView _instance;

        public string lang { get; set; } = "en";

        public ResourceManager resourceManager { get; set; }    
       
        public static ModelView Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModelView();
                }
                return _instance;
            }
        }

        /// <summary>
        /// default constructor
        /// </summary>
        private ModelView() {
            saves = new ManageSaves();

            CultureInfo culture = CultureInfo.CurrentCulture;

            switch (culture.Name.ToLower())
            {
                case "fr-fr":
                    lang = "fr";
                    break;
                default:
                    break;
            }

            this.resourceManager = new ResourceManager("EazySave_Master.Languages." + lang, Assembly.GetExecutingAssembly());

        }

        /// <summary>
        /// create an instance of save from the good type and add it to the ManageSaves
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        /// <param name="typeSave"></param>
        /// <param name="encryptList"></param>
        /// <param name="encryptKey"></param>
        public void createSave(string name, string sourceRepo, string targetPath, string typeSave, List<String> encryptList, string encryptKey)
        {
            switch (typeSave)
            {
                case "1":
                    saves.addSave(new SaveTotal(name, sourceRepo, targetPath, encryptList, encryptKey));
                    break;
                case "2":
                    saves.addSave(new SaveDifferential(name, sourceRepo, targetPath, encryptList, encryptKey));
                    break;
            }
        }

        /// <summary>
        /// launch save(s) from the numbers input user
        /// </summary>
        /// <param name="numbersUser">string numbers entered by user</param>
        public void runSavesFromNumbers(string numbersUser)
        {
             saves.RunSaves(numbersUser);
       
        }

        public void deleteSave (int number)
        {
            saves.deleteSave(number);
        }

        /// <summary>
        /// write the saves into file
        /// </summary>
        public void WriteSavesToFile()
        {/*
            //string json = JsonConvert.SerializeObject(GetListSaves(), Formatting.Indented);
            //File.WriteAllText(GetCompleteRootPathSaves(), json);
            string json = System.Text.Json.JsonSerializer.Serialize(saves.saves, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(GetCompleteRootPathSaves(), json);
        */}

        /// <summary>
        /// load the saves from the file
        /// </summary>
        public void LoadSavesFromFile()
        {
                /*
            if (File.Exists(GetCompleteRootPathSaves()))
            {
                // Lire le contenu du fichier JSON et le désérialiser en une liste d'items
                string json = File.ReadAllText(GetCompleteRootPathSaves());

                List<Save> concreteSaves = JsonConvert.DeserializeObject<List<Save>>(json);

                // Convertir la liste de ConcreteSave en ObservableCollection<Save>
                saves.saves = new List<Save>(concreteSaves.Cast<Save>());
            }
                */
        }

        private string GetCompleteRootPathSaves()
        {
            //path to the folder of logs from appdata
            string folder = EnumEasySaves.FolderRoot;
            string pathToFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), folder);
            //check existing directory in appdata
            if (!Directory.Exists(pathToFile))
            {
                Directory.CreateDirectory(pathToFile);
            }
            //name of file with extension
            string completeNameFile = "Saves.json";
            // concat full path
            return Path.Combine(pathToFile, completeNameFile);
        }

        /// <summary>
        /// return the list of saves
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Save> GetListSaves() 
        {
            return saves.saves;
        }

        public void updateResourceLang(string language)
        {
            this.resourceManager = new ResourceManager("EazySave_Master.Languages." + language, Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// update the extension used for the logs
        /// </summary>
        /// <param name="i"></param>
        public void UpdateExtensionLog(int i)
        {
            this.saves.logExtension = i;
        }


    }
}
