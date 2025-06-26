using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;
using System.IO;
using System.Linq;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTestEmptyFile
    {
        [TestMethod]
        public void CheckForEmptyFile()
        {
            // Arrange
            var currentDir = Directory.GetCurrentDirectory();
            currentDir = currentDir.Replace("\\bin\\Debug", ""); // Adjust the path to the project root directory
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; // Default path to the file


            // Act
            var names = File.ReadAllLines($"{pathToFile}{fileName}");
            // Assert
            Assert.IsTrue(names.Length > 0, "The file should not be empty.");
        }
    }
}
