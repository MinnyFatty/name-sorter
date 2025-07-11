﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;
using System.IO;
using System.Linq;

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
            Console.WriteLine($"Current Directory: {currentDir}");
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; // Default path to the file
            int lineNumber = 0;
            // Act
            var names = File.ReadAllLines($"{pathToFile}{fileName}");
            // Assert
            foreach (var name in names)
            {
                int currentLineNumber = lineNumber++;
                var parts = name.Split(' ');
                Assert.IsTrue(parts.Length >= 2, $"Error found in line:{lineNumber} for name:{name}, NOTE:Each line should contain greater than or equal two words i.e name and surname.");
            }
        }
    }
}
