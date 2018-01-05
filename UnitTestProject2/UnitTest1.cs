using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoopGen;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var loopGen = new LoopGen.LoopGenGenerator();
            loopGen.config.connectionStringName = "AdventureWorksDbContext";   // Connection string name from app.config/web.config
            loopGen.config.apiKey = "YOUR API KEY";                            // Get your Api Key by going to www.LoopGen.com
            loopGen.config.projectId = "AC2A56FF-7BD3-4774-900A-F98FE757B830"; // This is a unieque template for POCO
            loopGen.config.basePath = "../../AdventureWorks/";                 // Path to where the it'll put the generated files
            loopGen.config.namespaceName = "AdventureWorks.Generated";         // Namespace to use in generated objects

            var success = loopGen.generate();

            if (!success)
            {
                throw new Exception(loopGen.config.errorMessage);
            }
            Assert.IsTrue(success);
        }
    }
}