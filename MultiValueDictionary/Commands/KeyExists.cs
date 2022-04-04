using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class KeyExists : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.KEYEXISTS;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns whether a key exists or not
        /// </summary>
        /// <param name="parameters">key to be checked for its existence</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            bool writeDone = false;
            try
            {
                foreach (var item in dictionary)
                {
                    foreach (var param in parameters)
                    {
                        // Checking if key is present in the dictionary
                        if (item.Key.Equals(param.Key))
                        {
                            value = 1;
                            if (!writeDone)
                                writeDone = PrintLine(value);
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
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
            return true;
        }
    }
}
