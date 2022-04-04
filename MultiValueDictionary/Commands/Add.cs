using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Add : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.ADD;
        Dictionary<string, List<string>> ICommand.keyValuePairs { get { return valuePairs; } set => throw new NotImplementedException(); }

        /// <summary>
        /// Adds key,value to the dictionary
        /// </summary>
        /// <param name="parameters">key value pair to be added</param>
        /// <param name="dictionary">list of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            bool writeDone = false;
            try
            {
                valuePairs = parameters;
                foreach (var item in dictionary)
                {
                    foreach (var param in parameters)
                    {
                        if (item.Key.Equals(param.Key))
                        {
                            foreach (var itemValue in item.Value)
                            {
                                writeDone = true;
                                // Checks if the value is present in the dictionary for the given key
                                if (item.Value.Contains(param.Value[0]))
                                {
                                    valuePairs = dictionary;
                                    Console.WriteLine("ERROR, member already exists for key");
                                    break;
                                }
                                else
                                {
                                    valuePairs = parameters;
                                    Console.WriteLine("ADDED");
                                }
                                    
                            }
                        }
                    }
                }
                if (!writeDone)
                    Console.WriteLine("Added");
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
