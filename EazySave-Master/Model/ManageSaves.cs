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
            int n = IncrementNumberMaxSave();
            save.setNumber(n);
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

        private int IncrementNumberMaxSave()
        {
            int res = 0;
            int nSave = 0;
            foreach (Save save in saves)
            {
                nSave = save.number;
                if(nSave > res)
                    res = nSave;
            }
            return res=res+1;
        }
    }
}
