using CsvHelper;
using LookAndPlayForm.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LookAndPlayForm.LogData
{
    class ClassLogEngine
    {

        public static void Log(ClassLogData data)
        {
            string rootPath = CData.DataFolder + @"\";

            using (StreamWriter writer = File.AppendText(rootPath + @"log.txt"))
            {
                writer.WriteLine(
                    data.Date + "," +
                    data.Time_start + "," +
                    data.Time_end + "," +
                    data.Tester + "," +
                    data.Patient + "," +
                    data.testDone + "," +
                    data.number_of_screening_done + "," +
                    data.AssemblyVersion);
            }
        }

        public static ClassLogData GetLogByDate(List<ClassLogData> logs, string date)
        {
            if (logs == null || logs.Count < 1 || string.IsNullOrWhiteSpace(date))
                return null;

            foreach (ClassLogData log in logs)
            {
                try
                {
                    DateTime curdt = DateTime.Parse(date); // 2015-10-31 18:00:35Z
                    string scurdt = curdt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (scurdt == log.Date) // 18/08/2015                        
                    {
                        string st = curdt.ToString("HH:mm:ss"); // 11:45:01

                        if (log.Time_start.CompareTo(st) <= 0 && log.Time_end.CompareTo(st) >= 0)
                        {
                            return log;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }

            return null;
        }


        public static List<ClassLogData> ReadLog(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            List<ClassLogData> data = null;

            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader SR = new StreamReader(fileName))
                    {
                        data = new List<ClassLogData>();
                        while (!SR.EndOfStream)
                        {
                            try
                            {
                                string line = SR.ReadLine();
                                string[] entry = line.Split(',');
                                if (entry != null && entry.Length > 0)
                                {
                                    ClassLogData log = new ClassLogData();
                                    log.Date = entry[0];
                                    log.Time_start = entry[1];
                                    log.Time_end = entry[2];
                                    log.Tester = entry[3];
                                    log.Patient = entry[4];
                                    log.testDone = entry[5];
                                    log.number_of_screening_done = int.Parse(entry[6]);
                                    log.AssemblyVersion = entry[7];
                                    data.Add(log);
                                }
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return data;
        }

        /*
        public static List<ClassLogData> ReadLog(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            List<ClassLogData> data = null;

            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader SR = new StreamReader(fileName))
                    {
                        CsvReader reader = new CsvReader(SR);
                        try
                        {
                            data = reader.GetRecords<ClassLogData>().ToList();
                        }
                        catch (Exception ex)
                        {
                            ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return data;
        }*/
    }
}
