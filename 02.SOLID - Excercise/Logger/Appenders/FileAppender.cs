﻿using Logger.Loggers.Contracts;
using Logger.Loggers.Enums;

namespace Logger.Appenders
{
    using Layouts.Contracts;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "log.txt";

        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.MessagesCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + "\n";
                this.logFile.Write(content);
                File.AppendAllText(path, content);
            }
        }


        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}