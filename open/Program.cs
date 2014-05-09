using System;
using System.IO;
using open.openers;

namespace open
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 2) { 
                Console.WriteLine("-e {fileName} | {fileName}");
                return;
            }
            Open(args.Command(), args.Target());
        }

        public static void Open(string command, string target) {
            var openers = new Opener[] { new Explorer(), new Editor() };

            foreach (var opener in openers)
            {
                if (opener.CanProcess(command))
                {
                    opener.Open(target);
                }
            }        
        }
    }

    public static class ArgExtensions {
        public static string Command(this string[] args) {
            foreach (var arg in args) {
                if (arg.StartsWith("-")) {
                    return arg;
                }
            }
            return null;
        }

        public static string Target(this string[] args) {
            foreach (var arg in args)
            {
                if (!arg.StartsWith("-"))
                {
                    return arg;
                }
            }
            return ".";        
        }
    }
}
