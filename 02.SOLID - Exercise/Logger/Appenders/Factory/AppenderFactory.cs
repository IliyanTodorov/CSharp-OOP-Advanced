namespace Logger.Appenders.Factory
{
    using Appenders.Contracts;
    using Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLowerCase = type.ToLower();
            IAppender appender = null;

            switch (typeAsLowerCase)
            {
                case "consoleappender":
                    appender = new ConsoleAppender(layout);
                    break;
                case "fileappender":
                    appender = new FileAppender(layout, new LogFile());
                    break;
                default: throw new ArgumentException("Invalid appender type!");
            }

            return appender;
        }
    }
}