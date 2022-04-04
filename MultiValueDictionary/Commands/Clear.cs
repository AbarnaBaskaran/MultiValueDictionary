using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Commands
{
    internal class Clear : ICommand
    {
        private Dictionary<string, List<string>> valuePairs;
        public string Command => Constants.Constants.CLEAR;

        public Dictionary<string, List<string>> keyValuePairs { get => valuePairs; set => throw new NotImplementedException(); }

        /// <summary>
        /// Removes all keys and all members from dictionary
        /// </summary>
        /// <param name="parameters">No parameter required</param>
        /// <param name="dictionary">List of elements</param>
        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            try
            {
                if (dictionary.Any())
                {
                    // clears and initializes the dictionary
                    dictionary = new Dictionary<string, List<string>>();
                }
                valuePairs = new Dictionary<string, List<string>>();
                Console.WriteLine("Cleared");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
