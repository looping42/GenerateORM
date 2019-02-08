using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public static class DatabaseData
    {
        /// <summary>
        /// Récupére toute les bases de données correspondant au serveur passé en paramétres.
        /// </summary>
        /// <param name="serverName">serveur</param>
        /// <returns>array of string</returns>
        public static string[] GetDatabaseNames(string serverName)
        {
            var server = new Server(serverName);
            return (from Database database in server.Databases
                    where !database.IsSystemObject && !database.IsDatabaseSnapshot
                    select database.Name
                   ).ToArray();
        }

        public static string GetServiceIfEmpty()
        {
            var server = new Server();
            return server.Name;
        }
    }
}