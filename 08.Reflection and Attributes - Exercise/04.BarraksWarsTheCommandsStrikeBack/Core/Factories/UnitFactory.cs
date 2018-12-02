using System.Linq;

namespace _03BarracksFactory.Core.Factories
{
    using Contracts;
    using System;
    using System.Reflection;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

            var instance = (IUnit)Activator.CreateInstance(type, true);

            return instance;
        }
    }
}
