using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Items : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.ITEMS;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns all keys and members in the dictionary
        /// </summary>
        /// <param name="parameters">Not required</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            bool writeDone = false;
            try
            {
                foreach (var item in dictionary)
                {
                    value = 1;
                    if (!writeDone)
                        writeDone = PrintLine(value);
                    // Iterate through list of values for each key
                    foreach (var itemValue in item.Value)
                    {
                        value = 0;
                        Console.WriteLine(item.Key + ": " + itemValue);
                    }
                }
                if (!writeDone)
                    writeDone = PrintLine(value);
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
            if (value == 0)
                Console.WriteLine("Empty set");
            return true;
        }
    }
}
