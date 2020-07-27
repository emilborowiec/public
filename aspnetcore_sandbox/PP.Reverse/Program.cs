using System;

namespace PP.Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) return;
            var reverse = Reverse(args[0]);
            Console.WriteLine(reverse);
        }

        static string Reverse(string arg) 
        {
            if (arg == null) return null;
            var reverse = new char[arg.Length];
            for (var i = 0; i < arg.Length; i++) 
            {
                reverse[arg.Length - 1 - i] = arg[i];
            }
            return new string(reverse);
        }
    }
}
