using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalTreasury.Objects.DataObjects;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Drawing.Imaging;

namespace DigitalTreasury.Objects.Helpers
{
    public static class SqlHelper
    {
        public const string CreateTransactionsTableString =
        @"CREATE TABLE IF NOT EXISTS ""transactions"" (
            ""index"" INTEGER NOT NULL UNIQUE CHECK(""index"" >= 0),
            ""checkno""       INTEGER,
			""date""  TEXT NOT NULL DEFAULT (date('now')),
            ""amount""        NUMERIC NOT NULL DEFAULT 0,
			""collection""    TEXT,
            ""description""   TEXT,
            ""verified""      INTEGER NOT NULL DEFAULT 0 CHECK(""verified"" IN (0,1)),
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
        @"SELECT ""index"", ""checkno"", ""date"", ""amount"", ""collection"", ""description"", ""verified"" FROM transactions;";

        public const string SelectAllFromOrgString =
        @"SELECT ""name"", ""principle"" FROM organization;";

        public static string GetInsertIntoTransactionsString(Transaction t)
        {
            string index = t.Index.ToString();
            string checkNo = t.CheckNo.HasValue ? t.CheckNo.Value.ToString() : "NULL";
            string date = t.Date.ToString("yyyy-MM-dd");
            string amount = t.Amount.ToString();
            string collection = t.Collection;
            string description = t.Description;
            string verified = t.Verified ? "1" : "0";
            return $@"INSERT INTO transactions (""index"", ""checkno"", ""date"", ""amount"", ""collection"", ""description"", ""verified"") VALUES ({index}, '{checkNo}', '{date}', {amount}, '{collection}', '{description}', {verified});";
        }

        public static string GetInsertIntoOrgString(Organization o)
        {
            string name = o.Name;
            string principle = o.Principle.ToString();
            return $@"INSERT INTO organization (""name"", ""principle"") VALUES ('{name}', {principle})";
        }

        public static string GetSelectString(IEnumerable<string> columnNames, string table)
        {
            string columnsCSV = $@"""{string.Join("\",\"", columnNames)}"";";
            return $@"SELECT {columnsCSV} FROM {table};";
        }
    }
}
