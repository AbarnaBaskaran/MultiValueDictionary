using MultiValueDictionary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    internal static class BuilderFactory
    {
        private static List<ICommand> commands = new List<ICommand>();

        public static ICommand GetCommand(string commandParam, out Dictionary<string, List<string>> parameters)
        {
            parameters = GetArgsAsDict(commandParam);

            if (commands.Count == 0)
            {
                commands = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .Where(type => typeof(ICommand).IsAssignableFrom(type) && type.IsClass)
                                   .Select(type => Activator.CreateInstance(type))
                                   .Cast<ICommand>()
                                   .ToList();
            }
            return commands.Where(command => command.Command == commandParam.Split()[0]).FirstOrDefault();
        }

        /// <summary>
        /// Get the paramters from console
        /// </summary>
        /// <param name="commandParam">Parameters from console</param>
        /// <returns></returns>
        private static Dictionary<string, List<string>> GetArgsAsDict(string commandParam)
        {
            Dictionary<string, List<string>>? list = new Dictionary<string, List<string>>();
            try
            {
                var length = commandParam.Split(' ').Length;
                var parameters = commandParam.Split(' ').ToList();
                if (parameters.Count >= 2)
                {
                    int i = commandParam.IndexOf(" ") + 1;
                    var param = commandParam.Substring(i).Split().ToList<string>();

                    List<KeyValuePair<string, string>> value = Enumerable.Range(0, param.Count / 2).Select(i => new KeyValuePair<string, string>(param[i * 2], param[i * 2 + 1])).ToList();
                    list = value.Any() ? value.ToDictionary(x => x.Key, x => x.Value.Split(' ').ToList<string>()) : param.ToDictionary(x => x, x => x.Split().ToList<string>());

                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
