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
using EazySave_Master.View;

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

        public List<string> priorityList { get; set; }

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

        //// Nouvelle méthode pour ajouter une extension prioritaire
        //public void AddPriorityExtension(string extension)
        //{
        //    if (!PriorityExtensions.Contains(extension))
        //    {
        //        PriorityExtensions.Add(extension);
        //    }
        //}

        /// <summary>
        /// create an instance of save from the good type and add it to the ManageSaves
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        /// <param name="typeSave"></param>
        /// <param name="encryptList"></param>
        /// <param name="encryptKey"></param>
        public void createSave(string name, string sourceRepo, string targetPath, EnumEasySaves.TypeSave typeSave, List<String> encryptList, string encryptKey, List<string> priorityList)
        {
            switch (typeSave)
            {
                case EnumEasySaves.TypeSave.Total:
                    saves.addSave(new SaveTotal(name, sourceRepo, targetPath, encryptList, encryptKey));
                    break;
                case EnumEasySaves.TypeSave.Differential:
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
             saves.RunSavesAsync(numbersUser);
       
        }

        public void deleteSave (int number)
        {
            saves.deleteSave(number);
        }

        /// <summary>
        /// write the saves into file
        /// </summary>
        public void WriteSavesToFile()
        {
            using (StreamWriter writer = new StreamWriter(GetCompleteRootPathSaves()))
            {
                foreach (Save save in saves.saves)
                {
                    string line = $"{save.number},{save.name},{save.sourceRepo.path},{save.targetPath},{string.Join(";", save.encryptList)},{save.encryptKey},{save.GetType().FullName}";
                    writer.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// load the saves from the file
        /// </summary>
        public void LoadSavesFromFile()
        {
            string filePath = GetCompleteRootPathSaves();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        // tab from line
                        string[]? saveData = reader.ReadLine()?.Split(',');

                        if (saveData != null && saveData.Length == 8)
                        {
                            // create a save from the values
                            Save save = CreateSaveInstance(saveData);

                            saves.addSave(save);
                        }
                    }
                }
            }
        }

        private Save CreateSaveInstance(string[] saveData)
        {
            int number = int.Parse(saveData[0]);
            string name = saveData[1];
            string sourceRepoPath = saveData[2];
            string targetPath = saveData[3];
            List<string> encryptList = saveData[4].Split(';').ToList();
            string encryptKey = saveData[5];
            string saveType = saveData[6];

            // Utilisez le type de la save pour créer une instance concrète
            Type type = Type.GetType(saveType);
            Save save = (Save)Activator.CreateInstance(type, name, sourceRepoPath, targetPath, encryptList, encryptKey);
            save.setNumber(number);

            return save;
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
            string completeNameFile = "Saves.csv";
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

        /// <summary>
        /// Update the current ResourceManager to use the current language
        /// </summary>
        /// <param name="language"></param>
        public void updateResourceLang(string language)
        {
            this.resourceManager = new ResourceManager("EazySave_Master.Languages." + language, Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Update the extension used for the logs
        /// </summary>
        /// <param name="i"></param>
        public void UpdateExtensionLog(int i)
        {
            this.saves.logExtension = i;
        }

    }
}
