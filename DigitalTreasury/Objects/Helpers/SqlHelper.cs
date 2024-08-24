using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalTreasury.Objects.DataObjects;
using System.Web;

namespace DigitalTreasury.Objects.Helpers
{
    public static class SqlHelper
    {
        public const string CreateTransactionsTableString =
        @"CREATE TABLE IF NOT EXISTS ""transactions"" (
	        ""index""	INTEGER NOT NULL UNIQUE CHECK(""index"" >= 0),
	        ""date""	TEXT NOT NULL DEFAULT (date('now')),
	        ""amount""	NUMERIC NOT NULL DEFAULT 0,
	        ""description""	TEXT,
	        ""verified""	INTEGER NOT NULL DEFAULT 0 CHECK(""verified"" IN (0,1)),
            PRIMARY KEY(""index"")
        );";

        public const string CreateOrgTableString =
        @"CREATE TABLE IF NOT EXISTS ""organization"" (
            ""name""    TEXT NOT NULL,
            ""principle""   NUMERIC NOT NULL DEFAULT 0
        );";

        public const string DropTransactionsTableString =
        @"DROP TABLE IF EXISTS transactions;";

        public const string DropOrgTableString =
        @"DROP TABLE IF EXISTS organization;";

        public const string SelectAllTransactionsString =
        @"SELECT ""index"", ""date"", ""amount"", ""description"", ""verified"" FROM transactions;";

        public const string SelectAllFromOrgString =
        @"SELECT ""name"", ""principle"" FROM organization;";

        public static string GetInsertIntoTransactionsString(Transaction t)
        {
            return GetInsertIntoTransactionsString(t.Index, t.Date.ToString("yyyy-MM-dd"), t.Amount, t.Description, t.Verified ? 1 : 0);
        }
        public static string GetInsertIntoTransactionsString(int index, string date, decimal amount, string description, int verified)
        {
            return $@"INSERT INTO transactions (""index"", ""date"", ""amount"", ""description"", ""verified"") values ({index.ToString()}, '{date}', {amount.ToString()}, '{description}', {verified.ToString()});";
        }

        public static string GetInsertIntoOrgString(string name, decimal principle)
        {
            return $@"INSERT INTO organization (""name"", ""principle"") values ('{name}', {principle});";
        }

        public static string GetSelectString(IEnumerable<string> columnNames, string table)
        {
            string columnsCSV = $@"""{string.Join("\",\"", columnNames)}"";";
            return $@"SELECT {columnsCSV} FROM {table};";
        }
    }
}
