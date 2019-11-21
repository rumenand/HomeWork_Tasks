using System;
using System.Linq;
using CommandPattern.Core.Contracts;
using System.Reflection;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var tokens = args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            var commandName = tokens[0];
            var commandArgs = tokens.Skip(1).ToArray();

            var commandType = Assembly
               .GetCallingAssembly()
               .GetTypes()
               .Where(x => x.Name == $"{commandName}Command")
               .FirstOrDefault();
            var command = (ICommand) Activator.CreateInstance(commandType);
            return command.Execute(commandArgs);
        }
    }
}
