namespace _03BarracksFactory.Core.Command
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            var instance = (IExecutable)Activator.CreateInstance(type, new object[]
            {
                data, this.repository, this.unitFactory
            });

            return instance;
        }
    }
}