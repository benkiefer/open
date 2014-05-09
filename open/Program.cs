using System.Diagnostics;
using System.IO;
using open.openers;

namespace open
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) { 
                Debug.WriteLine("Please specify a file");
                return;
            }

            Process(args);
        }

        public static void Process(string[] args) {
            if (args.Length == 1)
            {
                Open(null, args[0]);
            }
            else
            {
                Open(args[0], args[1]);
            }
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

}
