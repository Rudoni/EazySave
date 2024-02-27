using EazySave_Master.Model;
using System.Diagnostics;
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

        /// <summary>
        /// return the list of saves
        /// </summary>
        /// <returns></returns>
        public List<Save> GetListSaves() 
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
