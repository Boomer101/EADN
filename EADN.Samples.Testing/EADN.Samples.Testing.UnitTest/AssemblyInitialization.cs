using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EADN.Samples.Testing.UnitTest
{
    [TestClass]
    public class AssemblyInitialization
    {
        [TestMethod]
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // Kann innerhalb Assembly nur 1x vorhanden sein
            // zb. Test-Files bereitstellen
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Test-Files wieder bereinigen
        }
    }
}