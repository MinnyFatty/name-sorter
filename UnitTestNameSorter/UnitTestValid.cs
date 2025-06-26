using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System.IO;
using System.Linq;

namespace UnitTestNameSorter
{
    [TestClass]
    public class UnitTestValidNames
    {
        [TestMethod]
        public void CheckForValidNames()
        {
            // Arrange
            var currentDir = Directory.GetCurrentDirectory();
            currentDir = currentDir.Replace("\\bin\\Debug", ""); // Adjust the path to the project root directory
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; // Default path to the file
            var outputFileName = $"{pathToFile}sorted_names-list.txt"; // Default output file name
            // Act
            var names = File.ReadAllLines($"{pathToFile}{fileName}");
            // Assert
            foreach (var name in names)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(name), "Name should not be null or whitespace.");
                Assert.IsTrue(name.Replace(" ", string.Empty).All(char.IsLetter), "Name should contain only letters.");
                Assert.IsTrue(name.Length > 0, "Name should not be empty.");
            }
        }

        


    }
}
