using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Console = Colorful.Console;
using CommandLine.Text;

namespace CommandLine.App
{
    internal class CommandLineArgs
    {
        [Option('f', "firstname", Required = true, HelpText = "Enter First name")]
        public string FirstName { get; set; }

        [Option('l', "lastname", Required = true, HelpText = "Enter Last Name")]
        public string LastName { get; set; }

        [Option("fruits", Separator = ':', HelpText = "Enter Last Name")]
        public IEnumerable<string> Fruits { get; set; }

        [Usage(ApplicationAlias = nameof(CommandLineArgs))]
        public static IEnumerable<Example> Examples => new List<Example>
        {
            new Example("\nUsing your name as arguments, this app will display your name", new CommandLineArgs
            {
                FirstName = "Joshua",
                LastName = "Van Daalen",
                Fruits = new List<string>()
                {
                    "Apple",
                    "Banana",
                    "Watermelon",
                },
            })
        };
    }
    class Program
    {
        static CommandLineArgs _options;

        static int Main(string[] args)
        {
            Console.WriteAscii("Command Line App", Color.Azure);
            var result = Parser.Default.ParseArguments<CommandLineArgs>(args).MapResult(
                   (CommandLineArgs opts) => Run(opts),
                   errs => 1);

            return result;
        }
        private static int Run(CommandLineArgs options)
        {
            _options = options;

            if (_options.Fruits.Any())
            {
                Console.WriteLine($"{_options.FirstName} {_options.LastName} likes to eat:");
                foreach (var f in _options.Fruits)
                {
                    Console.WriteLine($"\t{f}", Color.GreenYellow);
                }

            }
            else
            {
                Console.WriteLine($"{_options.FirstName} {_options.LastName} does not eat fruit!!!", Color.Crimson);
            }

            return 0;
        }
    }
}
