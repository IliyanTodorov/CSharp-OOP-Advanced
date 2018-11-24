using Logger.Core.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Logger.Appenders.Contracts;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                this.commandInterpreter.AddAppender(inputArgs);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split("|");

                this.commandInterpreter.AddMessage(inputArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}