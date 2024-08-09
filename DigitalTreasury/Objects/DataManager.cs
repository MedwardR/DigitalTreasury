using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Text.Json;
using DigitalTreasury.Objects.DataObjects;
using System.Drawing.Text;
using DigitalTreasury.Objects.Helpers;
using System.Security.Cryptography;
using System.Data.Common;
using DigitalTreasury.AppForms;
using System.Data;
using System.Windows.Forms;

namespace DigitalTreasury.Objects
{
    public class DataManager
    {
        private SqliteConnection m_dbConn;
        private int m_orgId;
        private Settings m_settings;

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
            m_dbConn.Open();

            Ledger ledger = new Ledger();
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
            for (int i = 0; reader.Read(); i++)
            {
                int index = reader.GetInt32(0);
                DateOnly date = DateOnly.FromDateTime(reader.GetDateTime(1));
                decimal amount = reader.GetDecimal(2);
                string description = reader.GetString(3);
                bool verified = reader.GetInt16(4) == 1;

                ledger.NewTransaction(index, date, amount, description, verified);
            }

            m_dbConn.Close();

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

            m_dbConn.Open();

            CreateNewTransactionsTable();
            CreateNewOrgTable();

            m_dbConn.Close();
        }

        public Organization GetOrganizationFromId(int orgId)
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
                return GetOrganizationFromId(orgId);
            }

            reader.Read();
            string orgName = "";
            decimal principle = 0;
            try
            {
                orgName = reader.GetString(0);
                principle = reader.GetDecimal(1);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message == "No data exists for the row/column.")
                {
                    CreateNewOrgTable();
                    return GetOrganizationFromId(orgId);
                }
            }

            m_dbConn.Close();
            return new Organization(orgId, orgName, principle);
        }

        private void CreateNewTransactionsTable()
        {
            m_dbConn.Open();

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.DropTransactionsTable;
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
            string orgName = dbSetup.OrgName;
            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.DropOrgTable;
                cmd.ExecuteNonQuery();
            }

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.CreateOrgTableString;
                cmd.ExecuteNonQuery();
            }

            using (SqliteCommand cmd = m_dbConn.CreateCommand())
            {
                cmd.CommandText = SqlHelper.GetInsertIntoOrgString(orgName);
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
