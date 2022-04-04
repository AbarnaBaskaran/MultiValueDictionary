using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    internal class Builder
    {
        private ICommand? command;

        public Builder(ICommand iCommand)
        {
            command = iCommand;
        }

        public void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary)
        {
            string result = command == null ? "Command doesn't exist. Please try valid commands" : "";
            
            if(!String.IsNullOrEmpty(result))
                Console.WriteLine(result);
            command?.Execute(parameters, dictionary);
        }
    }
}
