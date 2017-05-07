using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    internal class SqlTable
    {
        private string _con;

        private string selecttable = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";

        public SqlTable(string con)
        {
            this._con = con;
        }

        public List<string> Gettable()
        {
            List<string> table = new List<string>();
            using (SqlConnection con = new SqlConnection(_con))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(selecttable, con))
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
    }
}