using EazySave_Master.Model.Logs;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EazySave_Master.Model
{
    public class ManageSaves
    {
        /// <summary>
        /// List of saves
        /// </summary>
        public ObservableCollection<Save> saves { get; set; }
        /// <summary>
        /// Daily logs
        /// </summary>
        public FileDailyLogs dailyLogs { get; set; }
        /// <summary>
        /// Real time logs
        /// </summary>
        public FileRTLogs rtLogs { get; set; }
        /// <summary>
        /// extension used for the logs
        /// </summary>
        public int logExtension { get; set; }

        public List<string> priorityList { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public ManageSaves()
        {
            this.saves = new ObservableCollection<Save>();
            this.dailyLogs = new FileDailyLogs();
            this.rtLogs = new FileRTLogs();
            this.logExtension = (int)EnumEasySaves.LogFormat.Json;
        }

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


        public void deleteSave(int number)
        {
            for (int i = saves.Count - 1; i >= 0; i--)
            {
                if (saves[i].number == number)
                {
                    saves.RemoveAt(i);
                    break; 
                }
            }
        }

        /// <summary>
        /// launch all the saves from the list by his numbers (if string numbers OK)
        /// </summary>
        /// <param name="numbers"></param>
        public void RunSaves(string numbers)
        {
            List<int> listN = GetNumbersToExecute(numbers);
            foreach (var save in saves)
            {
                if (listN.Contains(save.number) && !IsSpecSoftwareRunning("devenv.exe"))
                {
                    RealTimeLog realTimeLog = new RealTimeLog();
                    long encryptionTime = 0;
                    bool res = save.ExecuteSave(priorityList, out encryptionTime);
                    //create log from save data
                    if (res)
                    {
                        realTimeLog.MaJFromSave(save);
                        dailyLogs.AddLog(new DailyLog(save, encryptionTime));
                        rtLogs.AddLog(realTimeLog);
                        realTimeLog.saveFinished();
                    }
                }
            }
            RunLogs();
        }
        /// <summary>
        /// run the logs from the type (ex:XML,JSON)
        /// </summary>
        private void RunLogs()
        {
            TypeFileLogs type;
            switch (logExtension)
            {
                case (int)EnumEasySaves.LogFormat.Json:
                    {
                        type = new JSONLogs();
                        break;
                    }
                case (int)EnumEasySaves.LogFormat.Xml:
                    {
                        type = new XMLLogs();
                        break;
                    }
                default:
                    {
                        type = new JSONLogs();
                        break;
                    }
            }
            if (!dailyLogs.IsEmpty())
            {
                type.RunLogs(dailyLogs);
                dailyLogs.EmptyLogs();

            }
            if (!rtLogs.IsEmpty())
            {
                type.RunLogs(rtLogs);
                rtLogs.EmptyLogs();
            }

        }

        /// <summary>
        /// return the next number from the biggest number of the saves
        /// </summary>
        /// <returns></returns>
        private int IncrementNumberMaxSave()
        {
            int res = 0;
            int nSave = 0;
            foreach (Save save in saves)
            {
                nSave = save.number;
                if (nSave > res)
                    res = nSave;
            }
            return res = res + 1;
        }

        /// <summary>
        /// return the list of saves (from numbers) to execute from the string input
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
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
        /// returns true if the process entered as a param is active
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        static bool IsSpecSoftwareRunning(string process)
        {
            return Process.GetProcessesByName(process).Length > 0;

        }
    }
}
