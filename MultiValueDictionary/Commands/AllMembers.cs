using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class AllMembers : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.ALLMEMBERS;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns all the members in the dictionary
        /// </summary>
        /// <param name="parameters">No parameter required</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            bool writeDone = false;
            // To check if there are elements in the dictionary
            try
            {
                if (dictionary.Any())
                {
                    foreach (var item in dictionary)
                    {
                        value = 1;
                        if (!writeDone)
                            writeDone = PrintLine(value);
                        // Iterating list of values in dictionary
                        foreach (var itemValue in item.Value)
                        {
                            value = 0;
                            Console.WriteLine(itemValue);
                        }
                    }
                }
                else
                    Console.WriteLine("(Empty set)");
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
                Console.WriteLine("MEMBERS are");
            else
                Console.WriteLine("(Empty set)");
            return true;
        }
    }
}
