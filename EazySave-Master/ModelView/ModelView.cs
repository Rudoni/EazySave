using EazySave_Master.Model;
using System.Diagnostics;

namespace EazySave_Master.ModelView
{
    /// <summary>
    /// ViewModel between the view and model ManageSaves
    /// </summary>
    internal class ModelView
    {
        public ManageSaves saves;

  
        private static ModelView _instance;

       
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
        }

        /// <summary>
        /// create an instance of save from the good type and add it to the ManageSaves
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourceRepo"></param>
        /// <param name="targetPath"></param>
        /// <param name="typeSave"></param>
        public void createSave(string name, string sourceRepo, string targetPath,string typeSave)
        {
            switch (typeSave)
            {
                case "1":
                    saves.addSave(new SaveTotal(name, sourceRepo, targetPath));
                    break;
                case "2":
                    saves.addSave(new SaveDifferential(name, sourceRepo, targetPath));
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

    }
}
