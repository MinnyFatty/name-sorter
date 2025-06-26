using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Inialization of SeedData directory
            var currentDir = Directory.GetCurrentDirectory();
            currentDir = currentDir.Replace("\\bin\\Debug", ""); // Adjust the path to the project root directory
            var fileName = "names.txt"; // Default file name;
            var pathToFile = $"{currentDir}\\SeedData\\"; //Default path to the file
            var sortedNamesFile = "sorted_names-list.txt"; // Default sorted names file name
            var outputFileName = $"{currentDir}\\SeedData\\{sortedNamesFile}"; //Default output file name
            #endregion

            #region Fetch the file name from arguments if provided
            if (args.Length == 0)
            {
                // Use the default file if no arguments are provided
                Console.WriteLine("Using default test file or seed data to initiate execution, if you want to use your own file, please provide location in arguments when executing exe file.");

                //generate SeedData directory if it does not exist
                if (!Directory.Exists(pathToFile))
                {
                    Directory.CreateDirectory(pathToFile);
                    Console.WriteLine($"Created directory: {pathToFile}");
                }
                else 
                { 
                    Console.WriteLine($"Using existing directory: {pathToFile}");
                }
            }
            else if (args.Length == 1)
            {
                // If one argument is provided, assume it's the file path
                var fileNameProvided = args[0];
                fileName = fileName.Split('/').Last();
                pathToFile = fileNameProvided.Substring(0, fileNameProvided.Length - fileName.Length).Trim();
                outputFileName = $"{pathToFile}{sortedNamesFile}";
                Console.WriteLine($"Using provided file: {fileName} to initiate execution.");
            }
            else
            {
                // Assuming the first argument is the file path
                var fileNameProvided = args[0];
                fileName = fileName.Split('/').Last();
                pathToFile = fileNameProvided.Substring(0, fileNameProvided.Length - fileName.Length).Trim();
                outputFileName = $"{pathToFile}{sortedNamesFile}";
                Console.WriteLine($"Using provided file: {fileName} to initiate execution, all other arguments will be ignored.");
            }

            #endregion

            string readContents;
            readContents = ReadFile($"{pathToFile}{fileName}");

            //clean up the lines to remove any leading or trailing whitespace or double spaces which could cause issues in sorting
            string readContentsCleaned = readContents.Replace("  ", "");

            Console.WriteLine("\nSorting names...");

            List<Person> personList = new List<Person>();
            AddToList(readContentsCleaned, personList);

            List<Person> personListSorted = new List<Person>();
            personListSorted = SortBySurnameThenName(personList);

            PrintSortedList(personListSorted);

            WriteToFile(outputFileName, personListSorted);

        }

        /// <summary>
        /// Reads the contents of a file and returns it as a string.
        /// </summary>
        /// <param name="file">This is the file path and file name that will be saved as a string.</param>
        /// <returns>String with contents of file.</returns>  
        private static string ReadFile(string file)
        {
            var result = string.Empty;

            try
            {
                using (StreamReader streamReader = new StreamReader(file, Encoding.UTF8))
                {
                    result = streamReader.ReadToEnd();
                }
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("File is empty or could not be read.");
                    return string.Empty;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>   
        /// Adds the names from the cleaned contents to a list of Person objects.
        /// </summary>
        /// <param name="readContentsCleaned"> Contents of file in string format that has already been cleaned of any unwanted whitespace.</param>
        /// <returns>List of Person objects.</returns>  
        private static void AddToList(string readContentsCleaned, List<Person> personList)
        {
            // Split the contents into lines
            string[] lines = readContentsCleaned.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in lines)
            {
                // Assuming each line contains a full name, split by space
                string surName = item.Split(' ').Last();
                string firstNames = item.Substring(0, item.Length - surName.Length).Trim();
                //Add the person to the list with an incremented ID - // assuming the ID is just a sequential number for reference to person after sorting
                if (string.IsNullOrWhiteSpace(surName) || string.IsNullOrWhiteSpace(firstNames))
                {
                    Console.WriteLine($"Skipping invalid entry: '{item}'");
                    continue; // Skip invalid entries
                }
                else
                {
                    personList.Add(new Person
                    {
                        Id = personList.Count + 1,
                        Names = firstNames,
                        Surname = surName
                    });
                }
            }
        }

        /// <summary>
        /// Sorts a list of Person objects by surname and then by name.
        /// </summary>
        /// <param name="personList">List of Person objects to be sorted.</param>
        /// <returns>Sorted list of Person objects.</returns>
        private static List<Person> SortBySurnameThenName(List<Person> personList)
        {
            //sort the list by surname then by name
            return personList.OrderBy(p => p.Surname).ThenBy(p => p.Names).ToList();
        }

        /// <summary>
        /// Prints the sorted list of Person objects to the console.
        /// </summary>
        /// <param name="personListSorted">Sorted list of Person objects.</param>
        /// <returns>Console output.</returns>
        private static void PrintSortedList(List<Person> personListSorted)
        {
            //Write the sorted names to the console
            Console.WriteLine("\n++++++Sorted names++++++\n");
            foreach (var person in personListSorted)
            {
                Console.WriteLine($"{person.Names} {person.Surname}");
            }
            Console.WriteLine("\n+++++++++++++++++++++++");
        }

        /// <summary>
        /// Writes the sorted list of Person objects to a file.
        /// </summary>
        /// <!-- <param name="outputFileName">The name of the output file.</param>-->
        /// <!-- <param name="personListSorted">Sorted list of Person objects.</param>-->
        /// <returns>File output.</returns>
        private static void WriteToFile(string outputFileName, List<Person> personListSorted)
        {
            //Write the sorted names to a file
            using (StreamWriter streamWriter = new StreamWriter(outputFileName, false, Encoding.UTF8))
            {
                foreach (var person in personListSorted)
                {
                    streamWriter.WriteLine($"{person.Names} {person.Surname}");
                }
            }
        }
    }
}
