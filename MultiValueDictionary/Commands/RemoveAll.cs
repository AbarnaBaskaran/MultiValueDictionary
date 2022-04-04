using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class RemoveAll : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.REMOVEALL;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Removes all members for a key and key from the dictionary
        /// </summary>
        /// <param name="parameters">key to be removed</param>
        /// <param name="dictionary">list of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            bool writeDone = false;
            try
            {
                if (dictionary.Count == 0)
                {
                    writeDone = true;
                    Console.WriteLine("ERROR, key does not exist");
                }
                    
                foreach (var item in dictionary)
                {
                    foreach (var param in parameters)
                    {
                        if (item.Key.Equals(param.Key))
                        {
                            value = 1;
                            if (!writeDone)
                                writeDone = PrintLine(value);
                            foreach (var itemValue in item.Value)
                            {
                                value = 0;
                                dictionary.Remove(item.Key);
                            }
                        }
                        else
                        {
                            
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
                Console.WriteLine("Removed");
            else
                Console.WriteLine("ERROR, Key does not exist");
            return true;
        }
    }
}
