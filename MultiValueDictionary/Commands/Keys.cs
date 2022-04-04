using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Keys : ICommand
    {
        public string Command => Constants.Constants.KEYS;

        private Dictionary<string, List<string>> valuePairs;
        Dictionary<string, List<string>> ICommand.keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns all the keys in the dictionary
        /// </summary>
        /// <param name="parameters">Not required</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            int count = 1;
            bool writeDone = false;
            // Iterate to print keys in the dictionary
            try
            {
                foreach (var item in dictionary)
                {
                    value = 1;
                    if (!writeDone)
                        writeDone = PrintLine(value);
                    Console.WriteLine(count + ") "+item.Key);
                    count++;
                }
                if (dictionary.Count == 0)
                    Console.WriteLine("Empty set");
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Prints the value to the console
        /// </summary>
        /// <param name="value">value to be printed</param>
        /// <returns>true</returns>
        private bool PrintLine(int value)
        {
            if (value == 1)
                Console.WriteLine("KEYS are");
            else
                Console.WriteLine("ERROR Key doesn't exist");
            return true;
        }
    }
}
