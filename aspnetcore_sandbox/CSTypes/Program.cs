using System.IO;
using System;

namespace CSTypes
{
    class PredefinedTypeMeta
    {
        public string Alias { get; set; }
        public Type Type { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
    }

    class Program
    {
        private static PredefinedTypeMeta[] predefinedTypes = {
            new PredefinedTypeMeta{
                Type = typeof(SByte),
                Alias = "sbyte",
                MinValue = sbyte.MinValue.ToString(),
                MaxValue = sbyte.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Byte),
                Alias = "byte",
                MinValue = byte.MinValue.ToString(),
                MaxValue = byte.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Int16),
                Alias = "short",
                MinValue = short.MinValue.ToString(),
                MaxValue = short.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(UInt16),
                Alias = "ushort",
                MinValue = ushort.MinValue.ToString(),
                MaxValue = ushort.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Int32),
                Alias = "int",
                MinValue = int.MinValue.ToString(),
                MaxValue = int.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(UInt32),
                Alias = "uint",
                MinValue = uint.MinValue.ToString(),
                MaxValue = uint.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Int64),
                Alias = "long",
                MinValue = long.MinValue.ToString(),
                MaxValue = long.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(UInt64),
                Alias = "ulong",
                MinValue = ulong.MinValue.ToString(),
                MaxValue = ulong.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Single),
                Alias = "float",
                MinValue = float.MinValue.ToString(),
                MaxValue = float.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Double),
                Alias = "double",
                MinValue = double.MinValue.ToString(),
                MaxValue = double.MaxValue.ToString()
            },
            new PredefinedTypeMeta{
                Type = typeof(Decimal),
                Alias = "decimal",
                MinValue = decimal.MinValue.ToString(),
                MaxValue = decimal.MaxValue.ToString()
            },
        };

        static void Main(string[] args)
        {
            var command = SelectCommand(args);
            switch (command)
            {
                case Command.ListTypes: 
                ListTypes();
                break;
                default:
                PrintUsage();
                break;
            }
        }

        private static Command SelectCommand(string[] args)
        {
            if (args == null || args.Length == 0) return Command.PrintUsage;
            if (args[0] == "--list" || args[0] == "-l") return Command.ListTypes;
            return Command.PrintUsage;
        }

        private static void ListTypes() 
        {
            foreach(PredefinedTypeMeta predefinedType in predefinedTypes)
            {
                Console.WriteLine($"{predefinedType.Type.ToString()}\t({predefinedType.Alias})\t\t[{predefinedType.MinValue} , {predefinedType.MaxValue}]");
            }
        }

        private static void PrintUsage()
        {
            PrintLines(new string[] {
                "Usage: CSTypes [option]",
                "",
                "Options:",
                "\t--list|-l: \tList C# predefined types",
                ""
            });
        }

        private static void PrintLines(string[] lines)
        {
            foreach(string line in lines) PrintLine(line);
        }

        private static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
