using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EADN.Samples.Testing.UnitTest
{
    [TestClass]
    public class DemoTests
    {
        Demo testObject;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Ausgabe während Test
            context.WriteLine("Class Initialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void InitTest()
        {
            // Resx testen
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            TestContext.WriteLine("Init Test");
            // Gemeinsames aufbauen
            // Arrange
            testObject = new Demo();
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            // Tests abbauen
        }

        [Owner("ab")]
        [TestCategory("Cat1")]
        [TestMethod]
        public void HappyPathTest()
        {
            // Arrange 
            // testObject ausgelagert nach InitTest()

            // Act
            string result = testObject.Foo("This is a test");

            // Assert
            Assert.IsNotNull(result, "The expected string must not be null");
            Assert.IsTrue(result.Contains("test"));
        }

        [TestMethod]
        public void AlternativePathTest()
        {
            // Arrange 
            // testObject ausgelagert nach InitTest()

            // Act
            string result = testObject.Foo("This is an alternative test");

            // Assert
            Assert.IsNotNull(result, "The expected string must not be null");
            Assert.IsTrue(result.Contains("test"));
            StringAssert.Contains(result, "test");

            // Inconclusive erzeugen
            // Assert.Inconclusive("Test under construction");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ExpectionalPathTest()
        {
            // Arrange
            Demo testObject = new Demo();

            // Act
            string result = testObject.Foo(null);

            // Assert nicht mehr nötig, weil [ExpectedException(typeof...)] erwartet wird
        }
    }
}