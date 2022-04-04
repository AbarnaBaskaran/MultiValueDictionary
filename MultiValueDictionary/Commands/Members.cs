using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Members : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.MEMBERS;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns the collection of string for the given value
        /// </summary>
        /// <param name="parameters">key</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            int count = 1;
            bool writeDone = false;
            try
            {
                foreach (var item in dictionary)
                {
                    foreach (var param in parameters)
                    {
                        // Checks if key is present
                        if (item.Key.Contains(param.Key))
                        {
                            value = 1;
                            if (!writeDone)
                                writeDone = PrintLine(value);
                            // Iterating through list of values for the key
                            foreach (var itemValue in item.Value)
                            {
                                value = 0;
                                Console.WriteLine(count +") "+ itemValue);
                                count++;
                            }
                        }
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
            if (value == 1)
                Console.WriteLine("MEMBERS are");
            else
                Console.WriteLine("ERROR, Key does not exist");
            return true;
        }
    }
}
