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
        private string _con;
        private string selecttable = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";

        public SqlTable(string con)
        {
            this._con = con;
        }

        public void CreateTableClass()
        {
            this.GenerateSqlTable(this.Gettable());
        }

        private List<string> Gettable()
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

        private string GenerateSqlTable(List<string> tableToExport)
        {
            string table = "";
            using (SqlConnection con = new SqlConnection(_con))
            {
                con.Open();

                foreach (string tableUnique in tableToExport)
                {
                    SqlCommand command = new SqlCommand(SqlRquestTableUNique, con);
                    command.Parameters.AddWithValue("@TableNameParam", tableUnique);

                    //command.Parameters.AddWithValue("@result", SqlDbType.VarChar);
                    //command.Parameters["@result"].Direction = ParameterDirection.Output;
                    //var result = command.ExecuteNonQuery();
                    //string name = (string)command.Parameters["@result"].Value;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            table += reader.GetString(0);
                            //string test = reader.GetString(1);
                        }
                    }
                    //SqlParameter retval = new SqlParameter("@result", SqlDbType.VarChar);
                    //retval.Direction = ParameterDirection.ReturnValue;
                    //string retunvalue = retval.Value.ToString();
                }
            }
            return table;
        }

        private string SqlRquestTableUNique = @"declare @TableName sysname = '@TableNameParam'
declare @result varchar(max) = 'public class ' + @TableName + '
{'
;with cte (ColumnName,column_id,ColumnType,ColumnDesc)
as
(
select ColumnName, column_id,ColumnType,ColumnDesc
from
(
    select
        replace(col.name, ' ', '_') ColumnName,
        column_id,
        case typ.name
            when 'bigint' then 'long'
            when 'binary' then 'byte[]'
            when 'bit' then 'bool'
            when 'char' then 'String'
            when 'date' then 'DateTime'
            when 'datetime' then 'DateTime'
            when 'datetime2' then 'DateTime'
            when 'datetimeoffset' then 'DateTimeOffset'
            when 'decimal' then 'decimal'
            when 'float' then 'float'
            when 'image' then 'byte[]'
            when 'int' then 'int'
            when 'money' then 'decimal'
            when 'nchar' then 'char'
            when 'ntext' then 'string'
            when 'numeric' then 'decimal'
            when 'nvarchar' then 'String'
            when 'real' then 'double'
            when 'smalldatetime' then 'DateTime'
            when 'smallint' then 'short'
            when 'smallmoney' then 'decimal'
            when 'text' then 'String'
            when 'time' then 'TimeSpan'
            when 'timestamp' then 'DateTime'
            when 'tinyint' then 'byte'
            when 'uniqueidentifier' then 'Guid'
            when 'varbinary' then 'byte[]'
            when 'varchar' then 'string'
            else 'UNKNOWN_' + typ.name
        END + CASE WHEN col.is_nullable=1 AND typ.name NOT IN ('binary', 'varbinary', 'image', 'text', 'ntext', 'varchar', 'nvarchar', 'char', 'nchar') THEN '?' ELSE '' END ColumnType,
        colDesc.colDesc AS ColumnDesc
    from sys.columns col
        join sys.types typ on
            col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id
    OUTER APPLY (
    SELECT TOP 1 CAST(value AS NVARCHAR(max)) AS colDesc
    FROM
       sys.extended_properties
    WHERE
       major_id = col.object_id
       AND
       minor_id = COLUMNPROPERTY(major_id, col.name, 'ColumnId')
    ) colDesc
    where object_id = object_id(@TableName)
) t
--order by column_id
)
select  'public ' + ColumnType + ' ' + ColumnName + ' { get; set; }'   from cte order by column_id";
    }
}