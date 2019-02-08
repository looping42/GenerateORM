using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateORM.Model
{
    public static class TemporaryRepertory
    {
        /// <summary>
        /// Creates the unique temporary directory.
        /// </summary>
        /// <returns>
        /// Directory path.
        /// </returns>
        public static string CreateUniqueTempDirectory()
        {
            var uniqueTempDir = Path.GetFullPath(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()));
            Directory.CreateDirectory(uniqueTempDir);
            return uniqueTempDir;
        }
    }
}