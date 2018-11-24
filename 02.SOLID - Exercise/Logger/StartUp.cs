using Logger.Core;
using Logger.Core.Contracts;

namespace Logger
{
    using Appenders;
    using Layouts;
    using Loggers;
    using Loggers.Enums;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
