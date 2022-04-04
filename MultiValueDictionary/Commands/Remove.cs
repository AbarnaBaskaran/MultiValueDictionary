using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Remove : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.REMOVE;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Removes a member from key
        /// </summary>
        /// <param name="parameters">key value pair</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            int value = 0;
            bool writeDone = false;
            bool remove = false;
            try
            {
                foreach (var item in dictionary.ToList())
                {
                    foreach (var param in parameters)
                    {
                        if (item.Key.Equals(param.Key))
                        {
                            foreach (var itemValue in item.Value.ToList())
                            {
                                // checking if value is present
                                if (itemValue.Equals(param.Value[0]))
                                {
                                    value = 1;
                                    if (!writeDone)
                                        writeDone = PrintLine(value);
                                    value = 0;
                                    item.Value.Remove(itemValue);
                                }
                                if (item.Value.Count() == 0)
                                    dictionary.Remove(item.Key);
                            }
                            if (!writeDone)
                            {
                                writeDone = true;
                                Console.WriteLine("ERROR, member does not exist");
                            }
                        }
                        else
                        {
                            if (!writeDone)
                                writeDone = PrintLine(value);
                        }
                    }
                }
                if (remove)
                    RemoveMember(parameters, dictionary);
                if (!writeDone)
                    writeDone = PrintLine(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RemoveMember(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            throw new NotImplementedException();
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
