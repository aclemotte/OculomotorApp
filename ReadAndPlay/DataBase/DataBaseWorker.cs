using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using LookAndPlayForm.Utility;
using CsvHelper;
using LookAndPlayForm.InstitutionID;
using LookAndPlayForm.TesterID;
using Newtonsoft.Json;
using System.Data;
using LookAndPlayForm.LogData;
using System.Windows.Forms;
using System.Globalization;

namespace LookAndPlayForm.DataBase
{
    /// <summary>
    /// This class allows to save/load application data to/from DB
    /// </summary>
    public sealed class DataBaseWorker
    {
        /// Private Variables
        #region Private Variables

        /// <summary>
        /// 
        /// </summary>
        static SQLiteDataBase dataBase;

        #endregion

        /// Schemas
        #region Schemas

        /// <summary>
        /// 
        /// </summary>
        static string table_institutions = "Institutions";
        static string schema_institutions = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT,  name TEXT)", table_institutions);
        static string insert_institutions = String.Format("INSERT OR REPLACE INTO {0} (ID, name) VALUES (\"{{0}}\",\"{{1}}\")", table_institutions);

        static string table_testers = "Testers";
        static string schema_testers = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT,  name TEXT)", table_testers);
        static string insert_testers = String.Format("INSERT OR REPLACE INTO {0} (ID, name) VALUES (\"{{0}}\",\"{{1}}\")", table_testers);

        static string table_users = "Users";
        static string schema_users = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, user_id TEXT, user_name TEXT, user_institution TEXT, user_age INTEGER, user_country TEXT, user_email TEXT, user_gender TEXT, strabismusExotropia BOOLEAN, strabismusEsotropia BOOLEAN, astigmatism BOOLEAN, nystagmus BOOLEAN, amblyopia BOOLEAN, hypermetropia BOOLEAN, myopia BOOLEAN, cranialNervePalsy BOOLEAN, ADHD BOOLEAN, dislexia BOOLEAN, other BOOLEAN, convergenceInsufficiency BOOLEAN)", table_users);
        static string insert_users = String.Format("INSERT OR REPLACE INTO {0} (user_id, user_name, user_institution, user_age, user_country, user_email, user_gender, strabismusExotropia, strabismusEsotropia, astigmatism, nystagmus, amblyopia, hypermetropia, myopia, cranialNervePalsy, ADHD, dislexia, other, convergenceInsufficiency) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\",\"{{3}}\",\"{{4}}\",\"{{5}}\",\"{{6}}\",\"{{7}}\",\"{{8}}\",\"{{9}}\",\"{{10}}\",\"{{11}}\",\"{{12}}\",\"{{13}}\",\"{{14}}\",\"{{15}}\",\"{{16}}\",\"{{17}}\",\"{{18}}\")", table_users);
        //static string insert_usersx = String.Format("INSERT INTO {0} (user_name, user_institution, user_age, user_country, user_email, user_gender, strabismusExotropia, strabismusEsotropia, astigmatism, nystagmus, amblyopia, hypermetropia, myopia, cranialNervePalsy, ADHD, dislexia, other, convergenceInsufficiency) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\",\"{{3}}\",\"{{4}}\",\"{{5}}\",\"{{6}}\",\"{{7}}\",\"{{8}}\",\"{{9}}\",\"{{10}}\",\"{{11}}\",\"{{12}}\",\"{{13}}\",\"{{14}}\",\"{{15}}\",\"{{16}}\",\"{{17}}\")", table_users);
        static string check_users_by_id = String.Format("SELECT user_id FROM {0} WHERE user_id=\"{{0}}\"", table_users);
        static string select_user_by_id = String.Format("SELECT user_name, user_institution, user_gender FROM {0} WHERE user_id=\"{{0}}\"", table_users);

        static string table_test = "Test";
        static string schema_test = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, user_id TEXT, tester_id TEXT, windows_username TEXT, date TIMESTAMP, date_loc TIMESTAMP, screen_Height INTEGER, screen_Width INTEGER, eyetracker TEXT, calibration_error_left_px INTEGER, calibration_error_right_px INTEGER, filter_type TEXT, typeTestDone INTEGER, readingTestTypeDone INTEGER, image2read TEXT, assemblyVersion TEXT, comments TEXT)", table_test);
        static string insert_test = String.Format("INSERT OR REPLACE INTO {0} (user_id, tester_id, windows_username, date, date_loc, screen_Height, screen_Width, eyetracker, calibration_error_left_px, calibration_error_right_px, filter_type, typeTestDone, readingTestTypeDone, image2read, assemblyVersion, comments) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\",\"{{3}}\",\"{{4}}\",\"{{5}}\",\"{{6}}\",\"{{7}}\",\"{{8}}\",\"{{9}}\",\"{{10}}\",\"{{11}}\",\"{{12}}\",\"{{13}}\",\"{{14}}\",\"{{15}}\")", table_test);
        static string get_test_id_by_date = String.Format("SELECT ID FROM {0} WHERE date=\"{{0}}\"", table_test);
        static string get_test_by_date_and_user_id = String.Format("SELECT ID FROM {0} WHERE date=\"{{0}}\" AND user_id=\"{{1}}\"", table_test);
        //static string check_test_by_date = String.Format("SELECT ID FROM {0} WHERE date=\"{{0}}\"", table_test);

        static string table_pursuit = "PursuitData";
        static string schema_pursuit = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, date TIMESTAMP, user_id TEXT, data TEXT)", table_pursuit);
        static string insert_pursuit = String.Format("INSERT OR REPLACE INTO {0} (date, user_id, data) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\")", table_pursuit);

        static string table_fix = "FixData";
        static string schema_fix = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, date TIMESTAMP, user_id TEXT, data TEXT)", table_fix);
        static string insert_fix = String.Format("INSERT OR REPLACE INTO {0} (date, user_id, data) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\")", table_fix);
        static string insert_fix_id = String.Format("INSERT OR REPLACE INTO {0} (ID, date, user_id, data) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\",\"{{3}}\")", table_fix);

        static string table_gaze = "GazeData";
        static string schema_gaze = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, date TIMESTAMP, user_id TEXT, data TEXT)", table_gaze);
        static string insert_gaze = String.Format("INSERT OR REPLACE INTO {0} (date, user_id, data) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\")", table_gaze);

        static string table_calibration = "CalibrationData";
        static string schema_calibration = String.Format("CREATE TABLE IF NOT EXISTS {0} (ID INTEGER PRIMARY KEY AUTOINCREMENT, date TIMESTAMP, user_id TEXT, data TEXT)", table_calibration);
        static string insert_calibration = String.Format("INSERT OR REPLACE INTO {0} (date, user_id, data) VALUES (\"{{0}}\",\"{{1}}\",\"{{2}}\")", table_calibration);

        #endregion

        /// Init
        #region Init

        /// <summary>
        /// Creates database in the current file path
        /// </summary>
        /// <param name="path">full file path to future DB</param>
        public static void CreateDataBase(string path)
        {
            try
            {
                if (dataBase != null)
                    Close();

                DataValidation.CheckDirectoryPath(path, true);
                dataBase = new SQLiteDataBase(path);

                dataBase.CreateTable(schema_institutions);
                dataBase.CreateTable(schema_testers);
                dataBase.CreateTable(schema_users);
                dataBase.CreateTable(schema_test);
                dataBase.CreateTable(schema_pursuit);
                dataBase.CreateTable(schema_fix);
                dataBase.CreateTable(schema_gaze);
                dataBase.CreateTable(schema_calibration);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString(), "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                Application.Exit();
            }
        }

        /// <summary>
        /// Closes DB finally
        /// </summary>
        public static void Close()
        {
            try
            {
                dataBase = null;
                SQLiteConnection.ClearAllPools();
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// Gets row count in the specified table
        /// </summary>
        /// <param name="tableName">specified table name</param>
        /// <returns>row count in table</returns>
        private static int GetRowCount(string tableName)
        {
            int count = 0;
            string res = dataBase.ExecuteScalar(string.Format("SELECT Count(*) FROM {0}", tableName));
            if (!string.IsNullOrWhiteSpace(res))
            {
                int.TryParse(res, out count);
            }
            return count;
        }

        #endregion

        /// Convert Existing Data
        #region Convert Existing Data

        /// <summary>
        /// Converts Old Existing Data to the New One from the specified directory
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        public static void ConvertExistingDataFrom(string path)
        {
            try
            {
                ConvertInstitutions(path);
                ConvertTesters(path);
                ConvertUsers(path);

                string[] dirs = Directory.GetDirectories(path);
                if (dirs != null && dirs.Length > 0)
                {
                    foreach (string dir in dirs)
                        ConvertExistingTestDataFrom(dir);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// Converts Old Existing Test Data to the New Test Data from the specified directory
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        private static void ConvertExistingTestDataFrom(string path)
        {
            ConvertTest(path);

            if (!DataValidation.DirectoryHasFiles(path))
            {
                try
                {
                    Directory.Delete(path);
                }
                catch (Exception) { }
            }
        }

        #endregion

        /// ConvertInstitutions
        #region ConvertInstitutions

        /// <summary>
        /// Converts institutions.csv into DB table
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        private static void ConvertInstitutions(string path)
        {
            string fpath = path + @"\institutions.csv";
            if (!File.Exists(fpath))
                return;

            try
            {
                using (StreamReader SR = new StreamReader(fpath))
                {
                    CsvReader reader = new CsvReader(SR);
                    try
                    {
                        List<institution_class_data> data = reader.GetRecords<institution_class_data>().ToList();
                        if (data != null)
                        {
                            foreach (institution_class_data entry in data)
                                dataBase.ExecuteNonQuery(String.Format(insert_institutions, entry.institution_id, entry.institution_name));
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        #endregion

        /// ConvertTesters
        #region ConvertTesters

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        private static void ConvertTesters(string path)
        {
            string fpath = path + @"\testers.csv";
            if (!File.Exists(fpath))
                return;

            try
            {
                using (StreamReader SR = new StreamReader(fpath))
                {
                    CsvReader reader = new CsvReader(SR);
                    try
                    {
                        List<TesterLoginEngineData> data = reader.GetRecords<TesterLoginEngineData>().ToList();
                        if (data != null)
                        {
                            foreach (TesterLoginEngineData entry in data)
                                dataBase.ExecuteNonQuery(String.Format(insert_testers, entry.tester_id, entry.tester_name));
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        #endregion

        /// ConvertUsers
        #region ConvertUsers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        private static void ConvertUsers(string path)
        {
            string fpath = path + @"\users.csv";
            if (!File.Exists(fpath))
                return;

            try
            {
                List<patient_class_datav3> data = PatientDataConverter.GetPatients(fpath);
                if (data != null)
                {
                    foreach (patient_class_datav3 entry in data)
                    {
                        string res = null;
                        if (GetRowCount(table_users) > 0)
                            res = dataBase.GetLine(String.Format(select_user_by_id, entry.user_id));
                        if (string.IsNullOrWhiteSpace(res))
                            insertUser(entry);
                        else
                        {
                            StringBuilder SB = new StringBuilder();
                            SB.AppendLine(entry.user_name);
                            SB.AppendLine(entry.user_institution);
                            SB.Append(entry.user_gender);
                            string usr = SB.ToString();
                            if (usr != res)
                                insertUser(entry);
                        }
                    }
                }

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }            
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        private static void insertUser(patient_class_datav3 entry)
        {
            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_users,
                                            entry.user_id, entry.user_name, entry.user_institution, entry.user_age, entry.user_country, entry.user_email, entry.user_gender,
                                            entry.user_diagnosedConditions.strabismusExotropia,
                                            entry.user_diagnosedConditions.strabismusEsotropia,
                                            entry.user_diagnosedConditions.astigmatism,
                                            entry.user_diagnosedConditions.nystagmus,
                                            entry.user_diagnosedConditions.amblyopia,
                                            entry.user_diagnosedConditions.hypermetropia,
                                            entry.user_diagnosedConditions.myopia,
                                            entry.user_diagnosedConditions.cranialNervePalsy,
                                            entry.user_diagnosedConditions.ADHD,
                                            entry.user_diagnosedConditions.dislexia,
                                            entry.user_diagnosedConditions.other,
                                            entry.user_diagnosedConditions.convergenceInsufficiency));
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        #endregion        

        /// Convert Test Data
        #region Convert Test Data

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        private static void ConvertTest(string path)
        {
            string fpath = path + @"\testData.json";

            string time = GetTime(path);
            if (string.IsNullOrWhiteSpace(time))
                return;

            string user_id = GetUserID(path);
            if (string.IsNullOrWhiteSpace(user_id))
                return;

            if (!File.Exists(fpath))
            {
                ConvertEyeTracker(path, time, user_id);
                ConvertFix(path, time, user_id);
                ConvertPursuit(path, time, user_id);
                ConvertCalibration(path, time, user_id);
                return;
            }            

            string data = FileWorker.ReadTextFile(fpath);
            if (string.IsNullOrWhiteSpace(data))
                return;

            string fpath2 = path + @"\comments.txt"; 
            string comments = "";
            if (File.Exists(fpath2))
            {
                try
                {
                    comments = FileWorker.ReadTextFile(fpath2);
                    File.Delete(fpath2);
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }

            try
            {                
                OutputTestData2 entry = JsonConvert.DeserializeObject<OutputTestData2>(data);
                if (entry != null)
                {
                    TestType testType = GetTestType(path); 
                    if (entry.typeTestDone != testType)
                        entry.typeTestDone = testType;

                    insertTestData(entry, user_id, comments);
                    time = entry.date;    
                        
                    File.Delete(fpath);
                }

                ConvertEyeTracker(path, time, user_id);
                ConvertFix(path, time, user_id);
                ConvertPursuit(path, time, user_id);
                ConvertCalibration(path, time, user_id);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="user_id"></param>
        /// <param name="comments"></param>
        private static void insertTestData(OutputTestData2 entry, string user_id, string comments)
        {
            if (entry == null)
                return;

            if (!string.IsNullOrWhiteSpace(user_id))
                entry.user_id = user_id;

            if (string.IsNullOrEmpty(entry.date_loc))
                entry.date_loc = DataConverter.RemoveZ(entry.date);

            if (string.IsNullOrEmpty(entry.windows_username))
                entry.windows_username = Environment.UserName;

            try
            {
                string res = dataBase.ExecuteScalar(string.Format(get_test_by_date_and_user_id, entry.date, user_id));
                if (string.IsNullOrWhiteSpace(res))
                {
                    // user_id, tester_id, windows_username, date, date_loc screen_Height, screen_Width, eyetracker, calibration_error_left_px, calibration_error_right_px, filter_type, typeTestDone, readingTestTypeDone, image2read, assemblyVersion
                    dataBase.ExecuteNonQuery(String.Format(insert_test,
                        entry.user_id,
                        entry.tester_id,
                        entry.windows_username,
                        entry.date,
                        entry.date_loc,
                        entry.screen_Height,
                        entry.screen_Width,
                        entry.eyetracker,
                        entry.calibration_error_left_px,
                        entry.calibration_error_right_px,
                        entry.filter_type,
                        (int)entry.typeTestDone,
                        (int)entry.readingTestTypeDone,
                        entry.image2read,
                        entry.assemblyVersion,
                        comments));
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// Gets user_id from the path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>user_id</returns>
        private static string GetUserID(string path)
        {
            string id = null;
            int pos = path.LastIndexOf("-us") + "-us".Length;
            if (pos >= 0)
                id = path.Substring(pos);
            return id;
        }

        private static TestType GetTestType(string path)
        {
            if (File.Exists(path + @"\" + CData.FileName_PursuitData))
                return TestType.persuit;
            else
                return TestType.reading;
        }

        private static string GetTime(string path)
        {
            // 2015-04-27 21:18:08Z
            string time = "";
            try
            {                
                time = Path.GetFileName(path);
                int pos = time.LastIndexOf("-us");
                time = time.Substring(0, pos);
                DateTime dt = DateTime.ParseExact(time, "yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
                return dt.ToString("yyyy-MM-dd HH:mm:ss") + 'Z';
            }
            catch(Exception ex)
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(time, "yyyy-MM-dd-HH-mm", CultureInfo.InvariantCulture);
                    return dt.ToString("yyyy-MM-dd HH:mm:ss") + 'Z';
                }
                catch (Exception exx)
                {
                    return "";
                }                
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        private static void ConvertEyeTracker(string path, string date, string user_id)
        {
            string fpath = path + @"\" + CData.FileName_EyeTrackerData;
            if (!File.Exists(fpath))
                return;

            string data = FileWorker.ReadTextFile(fpath);
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_gaze, date, user_id, DataConverter.ToUnescapedString(data)));

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        
        /// <summary>
        ///
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        private static void ConvertPursuit(string path, string date, string user_id)
        {
            string fpath = path + @"\" + CData.FileName_PursuitData;
            if (!File.Exists(fpath))
                return;

            string data = FileWorker.ReadTextFile(fpath);
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_pursuit, date, user_id, DataConverter.ToUnescapedString(data)));

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">directory which contains old data</param>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        private static void ConvertCalibration(string path, string date, string user_id)
        {
            string fpath = path + @"\" + CData.FileName_CalibrationData;
            if (!File.Exists(fpath))
                return;

            string data = FileWorker.ReadTextFile(fpath);
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_calibration, date, user_id, DataConverter.ToUnescapedString(data)));

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        private static void ConvertFix(string path, string date, string user_id)
        {
            string fpath = path + @"\" + CData.FileName_FixData;
            if (!File.Exists(fpath))
                return;

            string data = FileWorker.ReadTextFile(fpath);
            if (string.IsNullOrWhiteSpace(data))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_fix, date, user_id, DataConverter.ToUnescapedString(data)));

                File.Delete(fpath);
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        #endregion 
       
        /// Users
        #region Users

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void SaveUsers(List<patient_class_datav3> data)
        {
            if (data == null)
                return;

            foreach (patient_class_datav3 entry in data)
                insertUser(entry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void AddUser(patient_class_datav3 data)
        {
            if (data == null)
                return;
            
            insertUser(data);
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetUserIDByTestDate(string date)
        {
            string id = dataBase.ExecuteScalar(string.Format("SELECT user_id FROM {0} WHERE date=\"{1}\"", table_test, date));
            return id;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<patient_class_datav3> LoadUsers()
        {
            DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0}", table_users));
            if (dt == null)
                return null;

            List<patient_class_datav3> list = new List<patient_class_datav3>();

            try
            {
                foreach (DataRow entry in dt.Rows)
                {
                    try
                    {
                        patient_class_datav3 patient = new patient_class_datav3();
                        patient.user_id = entry["user_id"].ToString();
                        patient.user_age = entry["user_age"].ToString();
                        patient.user_email = entry["user_email"].ToString();
                        string gndr = entry["user_gender"].ToString().ToLower();
                        patient.user_gender = (gndr == "male") ? userGender.male : userGender.female;
                        patient.user_institution = entry["user_institution"].ToString();
                        patient.user_country = entry["user_country"].ToString();
                        patient.user_name = entry["user_name"].ToString();
                        patient.user_diagnosedConditions.ADHD = (bool)entry["ADHD"];
                        patient.user_diagnosedConditions.amblyopia = (bool)entry["amblyopia"];
                        patient.user_diagnosedConditions.astigmatism = (bool)entry["astigmatism"];
                        patient.user_diagnosedConditions.convergenceInsufficiency = (bool)entry["convergenceInsufficiency"];
                        patient.user_diagnosedConditions.cranialNervePalsy = (bool)entry["cranialNervePalsy"];
                        patient.user_diagnosedConditions.dislexia = (bool)entry["dislexia"];
                        patient.user_diagnosedConditions.hypermetropia = (bool)entry["hypermetropia"];
                        patient.user_diagnosedConditions.myopia = (bool)entry["myopia"];
                        patient.user_diagnosedConditions.nystagmus = (bool)entry["nystagmus"];
                        patient.user_diagnosedConditions.other = (bool)entry["other"];
                        patient.user_diagnosedConditions.strabismusEsotropia = (bool)entry["strabismusEsotropia"];
                        patient.user_diagnosedConditions.strabismusExotropia = (bool)entry["strabismusExotropia"];
                        list.Add(patient);
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return list;
        }

        #endregion

        /// Testers
        #region Testers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public static void SaveTesters(List<TesterLoginEngineData> data)
        {
            if (data == null)
                return;

            foreach (TesterLoginEngineData entry in data)
            {
                try
                {
                    dataBase.ExecuteNonQuery(String.Format(insert_testers, entry.tester_id, entry.tester_name));
                }
                catch (Exception ex)
                {
                    ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        public static void AddTester(TesterLoginEngineData entry)
        {
            if (entry == null)
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_testers, entry.tester_id, entry.tester_name));
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<TesterLoginEngineData> LoadTesters()
        {
            List<TesterLoginEngineData> list = null;

            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0}", table_testers));
                if (dt == null)
                    return null;

                list = new List<TesterLoginEngineData>();

                foreach (DataRow entry in dt.Rows)
                    try
                    {
                        list.Add(new TesterLoginEngineData(entry[0].ToString(), entry[1].ToString()));
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }

                dt.Dispose();
                dt = null;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return list;
        }

        #endregion

        /// Test
        #region Test

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user_id"></param>
        /// <param name="comments"></param>
        public static void SaveTestData(OutputTestData2 data, string user_id, string comments)
        {
            if (data == null)
                return;
            
            insertTestData(data, user_id, comments);
        }

        /*
        public static void LoadTestData()
        { }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="tester"></param>
        /// <param name="date"></param>
        /// <param name="testType">0 - none; 1 - pursuit; 2 - reading</param>
        /// <returns></returns>
        public static DataTable SearchTest(string patient, string tester, string date, int testType = 0)
        {
            DataTable dt = null;
            DataTable dt2 = null;

            try
            {
                StringBuilder SB = new StringBuilder();
                StringBuilder SB2 = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(patient))
                {
                    SB.Append(string.Format(" u.user_name LIKE \"{0}%\" ", patient));
                    SB2.Append(string.Format(" u.user_name LIKE \"{0}%\" ", patient));
                }

                bool doNotUseDT2 = false;
                if (!string.IsNullOrWhiteSpace(tester))
                {
                    SB.Append(string.Format(" t.name LIKE \"{0}%\" ", tester));
                    doNotUseDT2 = true;
                }

                if (!string.IsNullOrWhiteSpace(date))
                {
                    string dd = DataConverter.LocalDateFormat(date);
                    SB.Append(string.Format(" test.date_loc BETWEEN date(\"{0}\", '+0 day') AND date(\"{0}\", '+1 day') ", DataConverter.LocalDateFormat(date)));
                    SB2.Append(string.Format(" test.date_loc BETWEEN date(\"{0}\", '+0 day') AND date(\"{0}\", '+1 day') ", DataConverter.LocalDateFormat(date)));
                }

                string strTestType = (testType < 1 || testType > 2) ? "" : (testType == 1) ? "0" : "1";
                if (!string.IsNullOrWhiteSpace(strTestType))
                {
                    SB.Append(string.Format(" test.typeTestDone = \"{0}\"", strTestType));
                    SB2.Append(string.Format(" test.typeTestDone = \"{0}\"", strTestType));
                }

                string query = "";
                if (SB.Length > 0)
                {
                    query = "WHERE" + SB.Replace("  ", " AND ").ToString();
                }

                string query2 = "";
                if (SB2.Length > 0)
                {
                    query2 = "WHERE test.tester_id IS NULL OR test.tester_id = '' AND " + SB2.Replace("  ", " AND ").ToString();
                }
                else
                    query2 = "WHERE test.tester_id IS NULL OR test.tester_id = ''";

                dt = dataBase.GetDataTable(string.Format("SELECT u.user_id AS PatientID, u.user_name AS Patient, t.name AS Tester, test.date_loc AS Date, test.date AS DateUTC, test.typeTestDone AS TestType "
                    + "FROM {0} AS test "
                    + "INNER JOIN {1} AS u ON test.user_id = u.user_id "
                    + "INNER JOIN {2} AS t ON test.tester_id = t.ID "
                    + query, table_test, table_users, table_testers));

                if (!doNotUseDT2)
                {
                    dt2 = dataBase.GetDataTable(string.Format("SELECT u.user_id AS PatientID, u.user_name AS Patient, test.date_loc AS Date, test.date AS DateUTC, test.typeTestDone AS TestType "
                        + "FROM {0} AS test "
                        + "INNER JOIN {1} AS u ON test.user_id = u.user_id "
                        + query2, table_test, table_users));

                    foreach (DataRow row in dt2.Rows)
                    {
                        dt.ImportRow(row);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return dt;
        }

        /// <summary>
        /// Loads test data (TestData2) from the specified row
        /// </summary>
        /// <param name="row">row with test data</param>
        /// <returns>test data</returns>
        private static OutputTestData2 LoadTestDataFromRow(DataRow row)
        {
            if (row == null && row.ItemArray.Length < 1)
                return null;

            OutputTestData2 res = new OutputTestData2();
            // user_id, date, screen_Height, screen_Width, eyetracker, calibration_error_left_px, calibration_error_right_px, filter_type, typeTestDone, readingTestTypeDone, image2read, assemblyVersion
            res.date = DataConverter.UTCDateFromLocalTime(row["date"].ToString());
            res.date_loc = row["date_loc"].ToString();
            res.user_id = row["user_id"].ToString();
            res.tester_id = row["tester_id"].ToString();
            res.windows_username = row["windows_username"].ToString();
            res.assemblyVersion = row["assemblyVersion"].ToString();
            res.screen_Height = int.Parse(row["screen_Height"].ToString());
            res.screen_Width = int.Parse(row["screen_Width"].ToString());
            res.calibration_error_left_px = int.Parse(row["calibration_error_left_px"].ToString());
            res.calibration_error_right_px = int.Parse(row["calibration_error_right_px"].ToString());
            res.filter_type = row["filter_type"].ToString();
            res.typeTestDone = (TestType)int.Parse(row["typeTestDone"].ToString());
            res.readingTestTypeDone = (ReadingTestType)int.Parse(row["readingTestTypeDone"].ToString());
            res.eyetracker = row["eyetracker"].ToString();
            res.image2read = row["image2read"].ToString();
            res.comments = row["comments"].ToString();

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static OutputTestData2 LoadTestDataByDateAndID(string date, string user_id)
        {
            OutputTestData2 res = null;

            try
            {
                DataTable dt = null;
                if (date.Contains('Z')) // UTC time
                    dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_test, date, user_id));
                else // local time
                    dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE date_loc=\"{1}\" AND user_id=\"{2}\"", table_test, date, user_id));

                if (dt != null)
                {
                    res = LoadTestDataFromRow(dt.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return res;
        }

        #endregion

        /// Comments
        #region Comments

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static string LoadComments(string date, string user_id)
        {
            if (string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(date))
                return "";

            try
            {
                return dataBase.ExecuteScalar(string.Format("SELECT Comments FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_test, date, user_id));
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comments"></param>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        public static void SaveComments(string comments, string date, string user_id)
        {
            if (string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(date))
                return;

            try
            {
                dataBase.ExecuteScalar(string.Format("UPDATE {0} SET comments = \"{1}\" WHERE date=\"{2}\" AND user_id=\"{3}\"",comments, table_test, date, user_id));
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        #endregion

        /// Institutions
        #region Institutions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        public static void AddInstitution(institution_class_data entry)
        {
            if (entry == null)
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_institutions, entry.institution_id, entry.institution_name));
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        public static List<institution_class_data> LoadInstitutions()
        {
            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0}", table_institutions));
                if (dt == null)
                    return null;

                List<institution_class_data> list = new List<institution_class_data>();
                foreach (DataRow entry in dt.Rows)
                {
                    try
                    {
                        list.Add(new institution_class_data(entry[0].ToString(), entry[1].ToString()));
                    }
                    catch (Exception ex)
                    {
                        ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                return null;
            }
        }

        #endregion

        /// EyeTrackerData
        #region EyeTrackerData

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user_id"></param>
        /// <param name="date"></param>
        public static void SaveEyeTrackerData(string data, string user_id, string date)
        {
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(user_id))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_gaze, date, user_id, DataConverter.ToUnescapedString(data)));
            }
            catch(Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static string LoadEyeTrackerData(string date, string user_id)
        {
            string res = null;

            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_gaze, date, user_id));
                if (dt != null)
                {
                    res = DataConverter.FromUnescapedString(dt.Rows[0]["data"].ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return res;
        }

        #endregion

        /// CalibrationData
        #region CalibrationData

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user_id"></param>
        /// <param name="date"></param>
        public static void SaveCalibrationData(string data, string user_id, string date)
        {
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(user_id))
                return;

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_calibration, date, user_id, DataConverter.ToUnescapedString(data)));
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        public static void LoadCalibrationData()
        { }

        #endregion

        /// PursuitData
        #region PursuitData

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user_id"></param>
        /// <param name="date"></param>
        public static void SavePursuitData(string data, string user_id, string date)
        {
            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(date))
                throw new ArgumentNullException(string.Format("SavePursuitData\n{0}\n{1}\n{2}", data, user_id, date));

            try
            {
                dataBase.ExecuteNonQuery(String.Format(insert_pursuit, date, user_id, DataConverter.ToUnescapedString(data)));
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }   

        public static string LoadLastPursuitData(out string date, out string user_id, out string eyetracker, out OutputTestData2 testdata)
        {
            string res = null;
            date = null;
            user_id = null;
            eyetracker = null;
            testdata = null;

            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE ID = (SELECT MAX(ID) FROM {0})", table_pursuit));
                if (dt != null)
                {
                    date = DataConverter.UTCDateFromLocalTime(dt.Rows[0]["date"].ToString());
                    user_id = dt.Rows[0]["user_id"].ToString();
                    res = DataConverter.FromUnescapedString(dt.Rows[0]["Data"].ToString());

                    if (!string.IsNullOrWhiteSpace(date))
                    {
                        testdata = LoadTestDataByDateAndID(date, user_id);
                        eyetracker = LoadEyeTrackerData(date, user_id);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return res;
        }        

        
        public static string LoadPursuitData(string date, string user_id)
        {
            string res = null;

            try
            {
                if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(user_id))
                    throw new ArgumentNullException(string.Format("LoadPursuitData\n{0}\n{1}", date, user_id));

                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_pursuit, date, user_id));
                if (dt != null)
                {
                    res = DataConverter.FromUnescapedString(dt.Rows[0]["data"].ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return res;
        }

        #endregion

        /// Fix / Reading
        #region Fix / Reading

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user_id"></param>
        /// <param name="date"></param>
        public static void SaveFixData(string data, string user_id, string date)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(date))
                    throw new ArgumentNullException(string.Format("SaveFixData\n{0}\n{1}\n{2}", data, user_id, date));

                string res = LoadReadingData(date, user_id);
                if (string.IsNullOrWhiteSpace(res))
                {
                    int ires = dataBase.ExecuteNonQuery(String.Format(insert_fix, date, user_id, DataConverter.ToUnescapedString(data)));
                    //ErrorLog.ErrorLog.toErrorFile(string.Format("SaveFixData\nires {0} {2} {3}\n{1}", ires, data, user_id, date));
                }
                else
                {
                    if (res == data)
                        return;

                    string id = dataBase.ExecuteScalar(string.Format("SELECT ID FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_fix, date, user_id));
                    dataBase.ExecuteNonQuery(String.Format(insert_fix_id, id, date, user_id, DataConverter.ToUnescapedString(data)));
                }    
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        /// <param name="eyetracker"></param>
        /// <param name="testdata"></param>
        /// <returns></returns>
        public static string LoadLastReadingData(out string date, out string user_id, out string eyetracker, out OutputTestData2 testdata)
        {
            string res = null;
            date = null;
            user_id = null;
            eyetracker = null;
            testdata = null;

            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT date, user_id FROM {0} WHERE ID = (SELECT MAX(ID) FROM {0}) AND typeTestDone='1'", table_test));
                if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
                    return null;

                date = DataConverter.UTCDateFromLocalTime(dt.Rows[0]["date"].ToString());
                user_id = dt.Rows[0]["user_id"].ToString();

                if (!string.IsNullOrWhiteSpace(date) && !string.IsNullOrWhiteSpace(user_id))
                {
                    testdata = LoadTestDataByDateAndID(date, user_id);
                    eyetracker = LoadEyeTrackerData(date, user_id);
                    res = DataConverter.FromUnescapedString(LoadReadingData(date, user_id));
                }  
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public static string LoadReadingData(string date, string user_id)
        {
            string res = null;

            try
            {
                DataTable dt = dataBase.GetDataTable(string.Format("SELECT * FROM {0} WHERE date=\"{1}\" AND user_id=\"{2}\"", table_fix, date, user_id));
                if (dt != null)
                {
                    if (dt.Rows != null && dt.Rows.Count > 0)
                        res = DataConverter.FromUnescapedString(dt.Rows[0]["data"].ToString());
                }
            }
            catch (Exception ex)
            {
                ErrorLog.ErrorLog.toErrorFile(ex.GetBaseException().ToString());
                res = null;
            }

            return res;
        }

        #endregion
    }
}
