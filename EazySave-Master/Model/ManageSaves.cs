using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace EazySave_Master.Model
{
    class ManageSaves
    {
        public List<Save> saves { get; set; }

        public ManageSaves() { this.saves = new List<Save>(); }

        /**
         * add a save to the list of saves with his good number completed
         */
        public void addSave(Save save)
        {
            int n = IncrementNumberMaxSave();
            save.setNumber(n);
            saves.Add(save);
        }

        /**
         * launch all the saves from the list by his numbers (if string numbers OK)
         */
        public void RunSaves(string numbers)
        {
            List<int> listN=GetNumbersToExecute(numbers);
            foreach (var save in saves)
            {
                if(listN.Contains(save.number))
                    save.ExecuteSave();
            }
        }

        /**
         * return the next number from the biggest number of the saves
         */
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
            return res = res + 1;
        }

        /**
         * return the list of saves (from numbers) to execute from the string input
         */
        private List<int> GetNumbersToExecute(string numbers)
        {
            List<int> list = new List<int>();

            string[] separators = { ",", ";" };

            string[] tokens = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length == 1)
            {
                if (int.TryParse(numbers, out int number))
                {
                    list.Add(number);
                }
            }
            else if (tokens.Length > 1)
            {

                foreach (string token in tokens)
                {
                    if (int.TryParse(token, out int number))
                    {
                        list.Add(number);
                    }

                }
            }
            else
            {
                string[] rangeTokens = numbers.Split('-');
                if (rangeTokens.Length == 2 && int.TryParse(rangeTokens[0], out int start) && int.TryParse(rangeTokens[1], out int end))
                {
                    for (int i = start; i <= end; i++)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }

                    }
                }
            }
            if (list.Count < 1)
            {
                Console.WriteLine("Aucun nombre correct");
            }

            return list;
        }


    }
}
