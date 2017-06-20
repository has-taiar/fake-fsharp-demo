using System;
using Fake.Build.Demo.Core;

namespace Fake.Build.Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my very awesome calculator.........");

            var options = new CliParameters();
			var isValid = CommandLine.Parser.Default.ParseArgumentsStrict(args, options);

            if (!isValid)
            {
                Console.WriteLine("Please enter valid params. (ie: -o add -a 5 -b 3");
                Console.ReadKey();
                return;
            }

            var calculator = new Calculator();
            int result =0;
            switch(options.Type)
            {
                case OperationType.Add:
                    result = calculator.Add(options.a, options.b);

                    break;
                case OperationType.Multiply:
                    result = calculator.Multiply(options.a, options.b);

                    break;
            }

            Console.WriteLine("Operation Result: {0}", result);
			Console.ReadKey();
			return;
        }
    }
}
