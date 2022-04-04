// See https://aka.ms/new-console-template for more information
using MultiValueDictionary;
using MultiValueDictionary.Interfaces;
using System.Linq;

Console.WriteLine("Commands available are: KEYS,MEMBERS,ADD,REMOVE,REMOVEALL,CLEAR,KEYEXISTS,MEMBEREXISTS,ALLMEMBERS,ITEMS");
Dictionary<string, List<string>> valuePairs = new Dictionary<string, List<string>>();
while (true)
{
    Console.Write(">");
    string? input = Console.ReadLine();

    MultiValueDictionary.Builder builder = null;
    Dictionary<string, List<string>> parameters;
    ICommand command = BuilderFactory.GetCommand(input, out parameters);
    builder = new Builder(command);
    Console.Write(")");
    // Execute the command
    builder.Execute(parameters, valuePairs);
    // Maintain the collection
    valuePairs = DictionaryCollection(valuePairs, parameters, command);

}

/// <summary>
/// Maintain /ADD data to the collection
/// </summary>
Dictionary<string, List<string>> DictionaryCollection(Dictionary<string, List<string>> valuePairs, Dictionary<string, List<string>> parameters, ICommand command)
{
    if (command?.keyValuePairs != null)
    {
        valuePairs = command.keyValuePairs.Count == 0 ? command.keyValuePairs : valuePairs;
        foreach (var (item, param) in from item in valuePairs
                                      from param in parameters
                                      where item.Key.Equals(param.Key)
                                      from itemValue in item.Value
                                      select (item, param))
        {
            // Checks if the value is present in the dictionary for the given key
            if (item.Value.Contains(param.Value[0]))
            {
                break;
            }
            else
            {
                valuePairs[item.Key].Add(param.Value[0]);
                break;
            }
        }

        foreach (var item in command.keyValuePairs)
        {
            if (valuePairs.ContainsKey(item.Key)) { }
            else
                valuePairs.Add(item.Key, item.Value);
        }
    }

    return valuePairs;
}