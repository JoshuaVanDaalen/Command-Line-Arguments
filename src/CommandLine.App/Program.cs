using CommandLine.Text;
using System;
using System.Collections.Generic;

namespace CommandLine.App
{
    internal class CommandLineArgs
    {
        [Option('f', "firstname", Required = true, HelpText = "First name")]
        public string FirstName { get; set; }

        [Option('l', "lastname", Required = true, HelpText = "Last Name")]
        public string LastName { get; set; }

        [Usage(ApplicationAlias = nameof(CommandLineArgs))]
        public static IEnumerable<Example> Examples => new List<Example>
        {
            new Example("Using your name as arguments, this app will display your name.", new CommandLineArgs
            {
                FirstName = "Joshua",
                LastName = "Van Daalen",
            })
        };
    }
    class Program
    {
        static CommandLineArgs _options;

        static int Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<CommandLineArgs>(args).MapResult(
                   (CommandLineArgs opts) => Run(opts),
                   errs => 1);

            return result;
        }
        private static int Run(CommandLineArgs options)
        {
            _options = options;

            Console.WriteLine($"{_options.FirstName} {_options.LastName}");

            return 0;
        }
    }
}
