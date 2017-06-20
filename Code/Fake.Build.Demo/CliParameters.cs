using System;
using CommandLine;

namespace Fake.Build.Demo
{
    public class CliParameters
	{
		[Option('o', "operation", Required = true, HelpText = "operation to be performed")]
		public OperationType Type { get; set; }

		[Option('a', "a", Required = true, HelpText = "first number")]
	    public int a { get; set; }

		[Option('b', "b", Required = true, HelpText = "second number")]
		public int b { get; set; }
    }

    public enum OperationType
	{
	    Add, 
        Multiply
	}
}
