using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Interfaces
{
    internal interface ICommand
    {
        string Command { get; }
        Dictionary<string, List<string>> keyValuePairs { get; set; }
        void Execute(Dictionary<string, List<string>> parameters, Dictionary<string, List<string>> dictionary);
    }
}
