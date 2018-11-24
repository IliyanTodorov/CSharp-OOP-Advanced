namespace Logger.Loggers
{
    using Contracts;
    using System;
    using System.Linq;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string message)
        {
            this.Size += message.Where(Char.IsLetter).Sum(x => x);
        }
    }
}