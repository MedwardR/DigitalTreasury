using Microsoft.Data.Sqlite;
using System.Text.Json;
using DigitalTreasury.Objects.DataObjects;
using DigitalTreasury.Objects.Helpers;
using System.Data.Common;
using DigitalTreasury.AppForms;

namespace DigitalTreasury.Objects
{
    public class DataManager
    {
        private SqliteConnection m_dbConn;
        private int m_orgId;
        private Settings m_settings = new();

        public DataManager()
        {
            LoadSettings();
            GetNewDbConn(m_settings.LastOrgId);
        }
        public DataManager(int orgId)
        {
            LoadSettings();
            GetNewDbConn(orgId);
        }
        public DataManager(Organization org)
        {
            LoadSettings();
            GetNewDbConn(org.Id);
        }

        public Settings Settings
        {
            get
            {
                if (m_settings == null)
                {
                    LoadSettings();
                }
                return m_settings;
            }
        }

        public Ledger GetLedger()
        {
            Ledger ledger = new Ledger();

            Organization org = GetOrganizationFromId();
            ledger.Principle = org.Principle;

            m_dbConn.Open();

            SqliteCommand cmd = m_dbConn.CreateCommand();
            cmd.CommandText = SqlHelper.SelectAllTransactionsString;

            SqliteDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (DbException)
            {
                CreateNewDb(m_orgId);
                reader = cmd.ExecuteReader();
            }
            while (reader.Read())
            {
                Transaction t = new Transaction();

                t.Index = reader.GetInt32(0);
                if (!reader.IsDBNull(1))
                {
                    t.CheckNo = reader.GetInt32(1);
                }
                t.Date = DateOnly.FromDateTime(reader.GetDateTime(2));
                t.Amount = reader.GetDecimal(3);
                t.Collection = reader.GetString(4);
                t.Description = reader.GetString(5);
                t.Verified = reader.GetInt16(6) != 0;

                ledger.Transactions.Add(t);
            }

            m_dbConn.Close();

            ledger.ResetHasChanges();

            return ledger;
        }

        public void SaveLedger(Ledger ledger)
        {
            ledger.SortTransactionsByDate();

            CreateNewTransactionsTable();

            m_dbConn.Open();

            for (int i = 0; i < ledger.Transactions.Count; i++)
            {
                Transaction t = ledger.Transactions[i];
                t.Index = i;

                SqliteCommand cmd = m_dbConn.CreateCommand();
                cmd.CommandText = SqlHelper.GetInsertIntoTransactionsString(t);
                cmd.ExecuteNonQuery();
            }

            m_dbConn.Close();

            ledger.ResetHasChanges();
        }

        public void GetNewDbConn(int orgId)
        {
            m_orgId = orgId;

            string dbPath = GetDbFilePath(orgId);
            string connectionString = $"Data Source={dbPath};";
            m_dbConn = new SqliteConnection(connectionString);
        }

        public void CreateNewDb(int orgId)
        {
            GetNewDbConn(orgId);

            CreateNewTransactionsTable();
            CreateNewOrgTable();
        }

        public Organization GetOrganizationFromId()
        {
            m_dbConn.Open();

            SqliteCommand cmd = m_dbConn.CreateCommand();
            cmd.CommandText = SqlHelper.SelectAllFromOrgString;

            SqliteDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch
            {
                CreateNewOrgTable();
                return GetOrganizationFromId();
            }

            reader.Read();
            Organization org = new(m_orgId);
            try
            {
                org.Name = reader.GetString(0);
                org.Principle = reader.GetDecimal(1);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "No data exists for the row/column.")
                {
                    CreateNewOrgTable();
                    return GetOrganizationFromId();
                }
            }

            m_dbConn.Close();
            return org;
        }

        private void CreateNewTransactionsTable()
        {
            m_dbConn.Open();

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.DropTransactionsTableString;
                cmd.ExecuteNonQuery();
            }

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.CreateTransactionsTableString;
                cmd.ExecuteNonQuery();
            }

            m_dbConn.Close();
        }

        private void CreateNewOrgTable()
        {
            m_dbConn.Open();

            frmOrgSetup dbSetup = new frmOrgSetup();
            dbSetup.ShowDialog();
            Organization org = new(m_orgId);
            org.Name = dbSetup.OrgName;
            org.Principle = dbSetup.Principle;

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.DropOrgTableString;
                cmd.ExecuteNonQuery();
            }

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.CreateOrgTableString;
                cmd.ExecuteNonQuery();
            }

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.GetInsertIntoOrgString(org);
                cmd.ExecuteNonQuery();
            }

            m_dbConn.Close();
        }

        private void LoadSettings()
        {
            string settingsPath = GetSettingsFilePath();
            Settings settings;

            CreateAppDataDirectoryIfNone();

            if (File.Exists(settingsPath))
            {
                string jsonString = File.ReadAllText(settingsPath);
                settings = JsonSerializer.Deserialize<Settings>(jsonString) ?? InitializeSettingsFile();
            }
            else
            {
                settings = InitializeSettingsFile();
            }

            m_settings = settings;
        }

        public Settings InitializeSettingsFile()
        {
            Settings settings = new Settings
            {
                LastOrgId = 0,
                IsDebug = false
            };
            string jsonString = JsonSerializer.Serialize(settings);

            File.WriteAllText(GetSettingsFilePath(), jsonString);
            m_settings = settings;

            return settings;
        }

        public void CreateAppDataDirectoryIfNone()
        {
            string appDataPath = DataManager.GetAppDataPath();
            
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
        }

        public void SetupAllData()
        {
            CreateAppDataDirectoryIfNone();
            InitializeSettingsFile();
            CreateNewDb(0);
        }

        public static string GetSettingsFilePath()
        {
            string settingsFileName = "settings.json";
            return Path.Combine(GetAppDataPath(), settingsFileName);
        }

        public static string GetDbFilePath(int orgId)
        {
            string dbFileName = $"{orgId}.sqlite";
            return Path.Combine(GetAppDataPath(), dbFileName);
        }

        public static string GetAppDataPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DigitalTreasury");
        }

        public static bool AppDataExists()
        {
            string appDataPath = GetAppDataPath();
            if (Directory.Exists(appDataPath))
            {
                if (DirectoryHasFiles(appDataPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private static bool DirectoryHasFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"The specified directory does not exist: {directoryPath}");
            }

            string[] files = Directory.GetFiles(directoryPath);
            if (files.Length > 0)
            {
                return true;
            }

            string[] subdirectories = Directory.GetDirectories(directoryPath);
            foreach (var subdirectory in subdirectories)
            {
                if (DirectoryHasFiles(subdirectory))
                {
                    return true;
                }
            }

            return false;
        }

        //public static class Logging
        //{
        //    private const string Divider = "\n-------------------------------------------------------------------\n";

        //    private const string DividerError = "\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n";

        //    private static string GetLogPath()
        //    {
        //        return Path.Combine(GetAppDataPath(), "log.txt");
        //    }

        //    public static void WriteLine(string message)
        //    {
        //        File.AppendAllText(GetLogPath(), $"\n{DateTime.Now.ToString()}: {message}");
        //    }

        //    public static void LogNewSession()
        //    {
        //        File.AppendAllText(GetLogPath(), $"\n{Divider}New session started at: {DateTime.Now.ToString()}{Divider}");
        //    }

        //    public static void WriteException(Exception ex)
        //    {
        //        File.AppendAllText(GetLogPath(), $"{DividerError}Exception occurred at {DateTime.Now.ToString()}:\n{ex.Message}\n\n{ex.StackTrace}{DividerError}");
        //    }
        //}
    }
}
