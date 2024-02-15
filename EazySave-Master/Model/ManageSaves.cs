
using System.Diagnostics;

namespace EazySave_Master.Model
{
    /// <summary>
    /// Class used to manage the list of saves
    /// </summary>
    class ManageSaves
    {
        /// <summary>
        /// list of saves
        /// </summary>
        public List<Save> saves { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public ManageSaves() { this.saves = new List<Save>(); }

        /// <summary>
        /// add a save to the list of saves with his good number completed
        /// </summary>
        /// <param name="save"></param>
        public void addSave(Save save)
        {
            int n = IncrementNumberMaxSave();
            save.setNumber(n);
            saves.Add(save);
        }

        /// <summary>
        /// launch all the saves from the list by his numbers (if string numbers OK)
        /// </summary>
        /// <param name="numbers"></param>
        public void RunSaves(string numbers)
        {
            List<int> listN=GetNumbersToExecute(numbers);
            foreach (var save in saves)
            {
                if(listN.Contains(save.number) && !IsSpecSoftwareRunning("devenv.exe"))
                    save.ExecuteSave();
            }
        }

        /// <summary>
        /// return the next number from the biggest number of the saves
        /// </summary>
        /// <returns>number in int</returns>
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

        /// <summary>
        /// return the list of saves (from numbers) to execute from the string input
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>list of numbers in list(int)</returns>
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

        /// <summary>
        /// chekcs if the specified process is active
        /// </summary>
        /// <param name="process">specific process name</param>
        /// <returns>true if the process entered as a param is active</returns>
        static bool IsSpecSoftwareRunning(string process)
        {
            return Process.GetProcessesByName(process).Length > 0;

        }
    }
}
