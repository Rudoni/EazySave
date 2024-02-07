using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EazySave_Master.Model
{
    class ManageSaves
    {
        public List<Save> saves { get; set; }

        public ManageSaves() { this.saves = new List<Save>(); }

        public void addSave(Save save)
        {
            saves.Add(save);
        }

        //TODO a completer
        public void RunSaves(string numbers)
        {
            //lancer les saves des numbers
            foreach (var save in saves)
            {
                save.ExecuteSave();
            }
        }
    }
}
