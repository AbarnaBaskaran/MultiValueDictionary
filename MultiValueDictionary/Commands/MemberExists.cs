using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class MemberExists : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.MEMBEREXISTS;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Returns whether a member exists within the key
        /// </summary>
        /// <param name="parameters">key value pair</param>
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
                        if (item.Key.Equals(param.Key))
                        {
                            foreach (var itemValue in item.Value)
                            {
                                // Checks if the value is present in the dictionary for the given key
                                if (itemValue.Equals(param.Value[0]))
                                {
                                    value = 1;
                                    if (!writeDone)
                                        writeDone = PrintLine(value);
                                    value = 0;
                                    Console.WriteLine(true);
                                }

                            }
                        }
                        else
                        {
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
            if (value == 0)
                Console.WriteLine(false);
            return true;
        }
    }
}
