using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using name_sorter;
using System.IO;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTest2Names
    {
        [TestMethod]
        public void CheckFor2NamesPerLine()
        {
            // Arrange
            var currentDir = Directory.GetCurrentDirectory();
            currentDir = currentDir.Replace("\\bin\\Debug", ""); // Adjust the path to the project root directory
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; // Default path to the file
            // Act
            var names = File.ReadAllLines($"{pathToFile}{fileName}");
            // Assert
            foreach (var name in names)
            {
                var parts = name.Split(' ');
                Assert.IsTrue(parts.Length >= 2, "Each line should contain exactly two names.");
            }
        }
    }
}
