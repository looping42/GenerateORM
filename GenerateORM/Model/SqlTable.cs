using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    internal class SqlTable
    {
        private string connectionString;
        private string selectTable;
        private string selectGetterSetterTable;

        public SqlTable(string con, string selectTable, string selectGetterSetterTable)
        {
            this.connectionString = con;
            this.selectTable = selectTable;
            this.selectGetterSetterTable = selectGetterSetterTable;
        }

        public void CreateTableClass()
        {
            this.GenerateSqlTable(this.Gettable());
        }

        private List<string> Gettable()
        {
            List<string> table = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(selectTable, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        table.Add(reader.GetString(0));
                    }
                }
            }
            return table;
        }

        private List<StringBuilder> GenerateSqlTable(List<string> tableToExport)
        {
            List<StringBuilder> strTable = new List<StringBuilder>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (string tableUnique in tableToExport)
                {
                    StringBuilder str = new StringBuilder();

                    SqlCommand command = new SqlCommand(string.Format(selectGetterSetterTable, tableUnique), con);
                    command.Parameters.AddWithValue("@TableNameParam", tableUnique);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            str.Append(reader.GetString(0) + Environment.NewLine);
                        }
                    }
                    strTable.Add(str);
                }
            }
            return strTable;
        }
    }
}