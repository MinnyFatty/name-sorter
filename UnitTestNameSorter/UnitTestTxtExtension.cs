using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;
using System.IO;
using System.Linq;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTestTxtExtension
    {
        [TestMethod]
        public void CheckTxtExtension()
        {
            // Arrange
            var currentDir = Directory.GetCurrentDirectory();
            currentDir = currentDir.Replace("\\bin\\Debug", ""); // Adjust the path to the project root directory
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; // Default path to the file

            // Act
            var filePath = $"{pathToFile}{fileName}";
            // Assert
            Assert.IsTrue(filePath.EndsWith(".txt"), "The file should have a .txt extension.");
        }
    }
}
